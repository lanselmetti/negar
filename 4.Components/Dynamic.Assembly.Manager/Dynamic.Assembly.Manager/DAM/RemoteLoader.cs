#region using
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.IO;
using System.Reflection;
using Negar.DAM;

#endregion

namespace Negar.DAM
{
    /// <summary>
    /// The remote loader loads assumblies into a remote <see cref="AppDomain"/>
    /// </summary>
    public class RemoteLoader : MarshalByRefObject
    {

        #region Fields
        protected ArrayList _AssemblyList = new ArrayList();
        protected ArrayList _TypeList = new ArrayList();
        #endregion

        #region Methods

        #region public void LoadAssembly(String fullname)
        /// <summary>
        /// Loads the assembly into the remote domain
        /// </summary>
        /// <param name="fullname">The full filename of the assembly to load</param>
        public void LoadAssembly(String fullname)
        {
            String filename = Path.GetFileNameWithoutExtension(fullname);
            Assembly assembly = Assembly.Load(filename);
            _AssemblyList.Add(assembly);
            foreach (Type loadedType in assembly.GetTypes()) _TypeList.Add(loadedType);
        }
        #endregion

        #region public IList LoadScript(String filename, IList references)
        /// <summary>
        /// Loads the script into the remote domain
        /// </summary>
        /// <param name="filename">The full filename of the script to load</param>
        /// <param name="references">The dll references to compile with</param>
        /// <returns>A list of compiler errors if any.</returns>
        public IList LoadScript(String filename, IList references)
        {
            AssemblyFactory assemblyFactory = new AssemblyFactory();
            try
            {
                Assembly scriptAssembly = assemblyFactory.CreateAssembly(filename, references);
                _AssemblyList.Add(scriptAssembly);
                foreach (Type loadedType in scriptAssembly.GetTypes())
                    _TypeList.Add(loadedType);
                // No errors, return an empty list.
                return new ArrayList();
            }
            catch
            {
                ArrayList compilerErrors = new ArrayList();
                foreach (CompilerError error in assemblyFactory.CompilerErrors) compilerErrors.Add(error.ErrorText);
                return compilerErrors;
            }
        }
        #endregion

        #region public IList LoadScripts(IList filenames, IList references)
        /// <summary>
        /// Loads the scripts into the remote domain
        /// </summary>
        /// <param name="filenames">The filenames of the scripts to load</param>
        /// <param name="references">The dll references to compile with</param>
        /// <returns>A list of compiler errors if any</returns>
        public IList LoadScripts(IList filenames, IList references)
        {
            AssemblyFactory assemblyFactory = new AssemblyFactory();
            try
            {
                Assembly scriptAssembly = assemblyFactory.CreateAssembly(filenames, references);
                _AssemblyList.Add(scriptAssembly);
                foreach (Type loadedType in scriptAssembly.GetTypes()) _TypeList.Add(loadedType);

                // No errors, return an empty list.
                return new ArrayList();
            }
            catch
            {
                ArrayList compilerErrors = new ArrayList();
                foreach (CompilerError error in assemblyFactory.CompilerErrors) compilerErrors.Add(error.ErrorText);
                return compilerErrors;
            }
        }
        #endregion

        #region public String[] GetTypes()
        /// <summary>
        /// The types loaded by the plugin manager
        /// </summary>
        public String[] GetTypes()
        {
            ArrayList classList = new ArrayList();
            foreach (Type pluginType in _TypeList) classList.Add(pluginType.FullName);
            return (String[])classList.ToArray(typeof(String));
        }
        #endregion

        #region public String[] GetAssemblies()
        /// <summary>
        /// The assemblies loaded by the plugin manager
        /// </summary>
        public String[] GetAssemblies()
        {
            ArrayList assemblyNameList = new ArrayList();
            foreach (Assembly userAssembly in _AssemblyList) assemblyNameList.Add(userAssembly.FullName);
            return (String[])assemblyNameList.ToArray(typeof(String));
        }
        #endregion

        #region public String[] GetSubClasses(String baseClass)
        /// <summary>
        /// Retrieves the type objects for all subclasses of the given type within the loaded plugins.
        /// </summary>
        /// <param name="baseClass">The base class</param>
        /// <returns>All subclases</returns>
        public String[] GetSubclasses(String baseClass)
        {
            Type baseClassType = Type.GetType(baseClass);
            if (baseClassType == null) baseClassType = GetTypeByName(baseClass);
            if (baseClassType == null) throw new ArgumentException("Cannot find a type of name " + baseClass +
                " within the plugins or the common library.");
            ArrayList subclassList = new ArrayList();
            foreach (Type pluginType in _TypeList)
                if (pluginType.IsSubclassOf(baseClassType)) subclassList.Add(pluginType.FullName);
            return (String[])subclassList.ToArray(typeof(String));
        }
        #endregion

        #region public MarshalByRefObject CreateInstance(String typeName, BindingFlags bindingFlags, object[] CtorParams)
        /// <summary>
        /// Returns a proxy to an instance of the specified plugin type
        /// </summary>
        /// <param name="typeName">The name of the type to create an instance of</param>
        /// <param name="bindingFlags">The binding flags for the constructor</param>
        /// <param name="CtorParams">The parameters to pass to the constructor</param>
        /// <returns>The constructed object</returns>
        public MarshalByRefObject CreateInstance(String typeName, BindingFlags bindingFlags, object[] CtorParams)
        {
            Assembly owningAssembly = null;
            foreach (Assembly assembly in _AssemblyList) if (assembly.GetType(typeName) != null) owningAssembly = assembly;
            if (owningAssembly == null)
                throw new InvalidOperationException("Could not find owning assembly for type " + typeName);
            MarshalByRefObject createdInstance = owningAssembly.CreateInstance(typeName, false, bindingFlags, null,
                CtorParams, null, null) as MarshalByRefObject;
            if (createdInstance == null)
                throw new ArgumentException("typeName must specify a Type that derives from MarshalByRefObject");
            return createdInstance;
        }
        #endregion

        #region public Boolean ManagesType(String typeName)
        /// <summary>
        /// Determines if this loader manages the specified type
        /// </summary>
        /// <param name="typeName">The type to check if this PluginManager handles</param>
        /// <returns>True if this PluginManager handles the type</returns>
        public Boolean ManagesType(String typeName)
        {
            return (GetTypeByName(typeName) != null);
        }
        #endregion

        #region private Type GetTypeByName(String typeName)
        /// <summary>
        /// Returns the Type object by FullName
        /// </summary>
        /// <param name="typeName">The plugin Type to look up</param>
        /// <returns>The Type object for the specified type name; null if not found</returns>
        private Type GetTypeByName(String typeName)
        {
            foreach (Type pluginType in _TypeList) if (pluginType.FullName == typeName) return pluginType;
            return null;
        }
        #endregion

        #region public Object GetStaticPropertyValue(String typeName, String propertyName)
        /// <summary>
        /// Returns the value of a static property
        /// </summary>
        /// <param name="typeName">The type to retrieve the static property value from</param>
        /// <param name="propertyName">The name of the property to retrieve</param>
        /// <returns>The value of the static property</returns>
        public Object GetStaticPropertyValue(String typeName, String propertyName)
        {
            Type type = GetTypeByName(typeName);
            if (type == null) throw new ArgumentException("Cannot find a type of name " + typeName +
                " within the plugins or the common library.");
            return type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Static).GetValue(null, null);
        }
        #endregion

        #region public Object CallStaticMethod(String typeName, String methodName, Object[] methodParams)
        /// <summary>
        /// Returns the result of a static method call
        /// </summary>
        /// <param name="typeName">The type to call the static method on</param>
        /// <param name="methodName">The name of the method to call</param>
        /// <param name="methodParams">The parameters to pass to the method</param>
        /// <returns>The return value of the method</returns>
        public Object CallStaticMethod(String typeName, String methodName, Object[] methodParams)
        {
            Type type = GetTypeByName(typeName);
            if (type == null)
                throw new ArgumentException("Cannot find a type of name " + typeName +
                    " within the plugins or the common library.");
            return type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static).
                Invoke(null, BindingFlags.Public | BindingFlags.Static, null, methodParams, null);
        }
        #endregion

        #endregion

    }
}