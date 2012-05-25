#region using
using System;
using System.Collections;
using System.IO;
using System.Reflection;
#endregion

namespace Negar.DAM
{
    /// <summary>
    /// Local loader class
    /// </summary>
    public class LocalLoader : MarshalByRefObject
    {

        #region Fields
        private readonly RemoteLoader _RemoteLoader;
        private AppDomain _CurrentAppDomain;
        #endregion

        #region Properties

        #region String[] Assemblies
        /// <summary>
        /// The list of loaded plugin assemblies
        /// </summary>
        public String[] Assemblies
        {
            get { return _RemoteLoader.GetAssemblies(); }
        }
        #endregion

        #region String[] Types
        /// <summary>
        /// The list of loaded plugin types
        /// </summary>
        public String[] Types
        {
            get { return _RemoteLoader.GetTypes(); }
        }
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// Creates the local loader class
        /// </summary>
        /// <param name="pluginDirectory">The plugin directory</param>
        public LocalLoader(String pluginDirectory)
        {
            AppDomainSetup setup = new AppDomainSetup();
            setup.ApplicationName = "Plugins";
            setup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
            setup.PrivateBinPath = Path.GetDirectoryName(pluginDirectory).Substring(
                Path.GetDirectoryName(pluginDirectory).LastIndexOf(Path.DirectorySeparatorChar) + 1);
            setup.CachePath = Path.Combine(pluginDirectory, "cache" + Path.DirectorySeparatorChar);
            setup.ShadowCopyFiles = "true";
            setup.ShadowCopyDirectories = pluginDirectory;
            _CurrentAppDomain = AppDomain.CreateDomain("Plugins", null, setup);
            _RemoteLoader = (RemoteLoader)_CurrentAppDomain.
                CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().GetName().Name, "Negar.DAM.RemoteLoader");
        }
        #endregion

        #region Methods

        #region public void LoadAssembly(String filename)
        /// <summary>
        /// Loads the specified assembly
        /// </summary>
        /// <param name="filename">The filename of the assembly to load</param>
        public void LoadAssembly(String filename)
        {
            _RemoteLoader.LoadAssembly(filename);
        }
        #endregion

        #region public IList LoadScript(String filename)
        /// <summary>
        /// Loads the specified script
        /// </summary>
        /// <param name="filename">The filename of the script to load</param>
        /// <returns>A list of compiler errors if any</returns>
        public IList LoadScript(String filename)
        {
            return LoadScript(filename, new ArrayList());
        }
        #endregion

        #region public IList LoadScript(String filename, IList references)
        /// <summary>
        /// Loads the specified script
        /// </summary>
        /// <param name="filename">The filename of the script to load</param>
        /// <param name="references">The dll references to compile with</param>
        /// <returns>A list of compiler errors if any</returns>
        public IList LoadScript(String filename, IList references)
        {
            return _RemoteLoader.LoadScript(filename, references);
        }
        #endregion

        #region public IList LoadScripts(IList filenames)
        /// <summary>
        /// Loads the specified scripts
        /// </summary>
        /// <param name="filenames">The filenames of the scripts to load</param>
        /// <returns>A list of compiler errors if any</returns>
        public IList LoadScripts(IList filenames)
        {
            return LoadScripts(filenames, new ArrayList());
        }
        #endregion

        #region public IList LoadScripts(IList filenames, IList references)
        /// <summary>
        /// Loads the specified scripts
        /// </summary>
        /// <param name="filenames">The filenames of the scripts to load</param>
        /// <param name="references">The dll references to compile with</param>
        /// <returns>A list of compiler errors if any</returns>
        public IList LoadScripts(IList filenames, IList references)
        {
            return _RemoteLoader.LoadScripts(filenames, references);
        }
        #endregion

        #region public void Unload()
        /// <summary>
        /// Unloads the plugins
        /// </summary>
        public void Unload()
        {
            AppDomain.Unload(_CurrentAppDomain);
            _CurrentAppDomain = null;
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
            return _RemoteLoader.GetSubclasses(baseClass);
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
            return _RemoteLoader.ManagesType(typeName);
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
            return _RemoteLoader.GetStaticPropertyValue(typeName, propertyName);
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
            return _RemoteLoader.CallStaticMethod(typeName, methodName, methodParams);
        }
        #endregion

        #region public MarshalByRefObject CreateInstance(String typeName, BindingFlags bindingFlags, Object[] CtorParams)
        /// <summary>
        /// Returns a proxy to an instance of the specified plugin type
        /// </summary>
        /// <param name="typeName">The name of the type to create an instance of</param>
        /// <param name="bindingFlags">The binding flags for the constructor</param>
        /// <param name="CtorParams">The parameters to pass to the constructor</param>
        /// <returns>The constructed object</returns>
        public MarshalByRefObject CreateInstance(String typeName, BindingFlags bindingFlags, Object[] CtorParams)
        {
            return _RemoteLoader.CreateInstance(typeName, bindingFlags, CtorParams);
        }
        #endregion

        #endregion

    }
}