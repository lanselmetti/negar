#region using
using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading;
#endregion

namespace Negar.DAM
{
    /// <summary>
    /// The PluginManager tracks changes to the plugin directory, handles reloading of the plugins,
    /// and monitoring the plugin directory.
    /// </summary>
    public class PluginManager
    {

        #region Fields
        protected Boolean active = true;
        private Boolean autoReload = true;
        protected Boolean beginShutdown;
        protected DateTime changeTime = new DateTime(0);
        private IList compilerErrors;
        protected FileSystemWatcher fileSystemWatcher;
        private Boolean ignoreErrors = true;
        protected LocalLoader localLoader;
        protected String lockObject = "{PLUGINMANAGERLOCK}";
        protected AppDomain pluginAppDomain;
        protected AppDomainSetup pluginAppDomainSetup;
        protected String pluginDirectory;
        protected Thread pluginReloadThread;
        private PluginSourceEnum pluginSources = PluginSourceEnum.Both;
        protected IList references = new ArrayList();
        protected RemoteLoader remoteLoader;
        private Boolean started;
        #endregion

        #region Events

        #region EventHandler PluginsReloaded
        /// <summary>
        /// Fires when the plugins have been reloaded and references to the old objects need
        /// to be updated.
        /// </summary>
        public event EventHandler PluginsReloaded;
        #endregion

        #endregion

        #region Properties

        #region Boolean AutoReload
        /// <summary>
        /// Should auto reload on file changes
        /// </summary>
        public Boolean AutoReload
        {
            get { return autoReload; }
            set
            {
                if (autoReload != value)
                {
                    autoReload = value;
                    if (!autoReload)
                    {
                        fileSystemWatcher.EnableRaisingEvents = false;
                        Stop();
                        pluginReloadThread = null;
                        fileSystemWatcher = null;
                    }
                    else
                    {
                        fileSystemWatcher = new FileSystemWatcher(pluginDirectory);
                        fileSystemWatcher.EnableRaisingEvents = true;
                        fileSystemWatcher.Changed += fileSystemWatcher_Changed;
                        fileSystemWatcher.Deleted += fileSystemWatcher_Changed;
                        fileSystemWatcher.Created += fileSystemWatcher_Changed;

                        pluginReloadThread = new Thread(ReloadThreadLoop);
                        pluginReloadThread.Start();
                    }
                }
            }
        }
        #endregion

        #region Boolean IgnoreErrors
        /// <summary>
        /// Determines whether an exception will be thrown if a compiler error occurs in a script file
        /// </summary>
        public Boolean IgnoreErrors
        {
            get { return ignoreErrors; }
            set { ignoreErrors = value; }
        }
        #endregion

        #region public PluginSourceEnum PluginSources
        /// <summary>
        /// The type of plugin sources that will be managed by the plugin manager
        /// </summary>
        public PluginSourceEnum PluginSources
        {
            get { return pluginSources; }
            set { pluginSources = value; }
        }
        #endregion

        #region IList CompilerErrors
        /// <summary>
        /// The list of all compiler errors for all scripts.
        /// Null if no compilation has ever occurred, empty list if compilation succeeded
        /// </summary>
        public IList CompilerErrors
        {
            get
            {
                if (!started) throw new InvalidOperationException("PluginManager has not been started.");
                return compilerErrors;
            }
        }
        #endregion

        #region String[] Assemblies
        /// <summary>
        /// The list of loaded plugin assemblies
        /// </summary>
        public String[] Assemblies
        {
            get
            {
                if (!started) throw new InvalidOperationException("PluginManager has not been started.");
                return localLoader.Assemblies;
            }
        }
        #endregion

        #region String[] Types
        /// <summary>
        /// The list of loaded plugin types
        /// </summary>
        public String[] Types
        {
            get
            {
                if (!started) throw new InvalidOperationException("PluginManager has not been started.");
                return localLoader.Types;
            }
        }
        #endregion

        #endregion

        #region Ctors

        #region public PluginManager() : this("ReportPlugins", true)
        /// <summary>
        /// Constructs a plugin manager
        /// </summary>
        public PluginManager()
            : this("ReportPlugins", true)
        {
        }
        #endregion

        #region public PluginManager(String pluginRelativePath) : this(pluginRelativePath, true)
        /// <summary>
        /// Constructs a plugin manager
        /// </summary>
        /// <param name="pluginRelativePath">The relative path to the plugins directory</param>
        public PluginManager(String pluginRelativePath)
            : this(pluginRelativePath, true)
        {
        }
        #endregion

        #region public PluginManager(Boolean autoReload) : this("ReportPlugins", autoReload)
        /// <summary>
        /// Constructs a plugin manager
        /// </summary>
        /// <param name="autoReload">Should auto reload on file changes</param>
        public PluginManager(Boolean autoReload)
            : this("ReportPlugins", autoReload)
        {
        }
        #endregion

        #region public PluginManager(String pluginRelativePath, Boolean autoReload)
        /// <summary>
        /// Constructs a plugin manager
        /// </summary>
        /// <param name="pluginRelativePath">The relative path to the plugins directory</param>
        /// <param name="autoReload">Should auto reload on file changes</param>
        public PluginManager(String pluginRelativePath, Boolean autoReload)
        {
            this.autoReload = autoReload;
            String assemblyLoc = Assembly.GetEntryAssembly().Location;
            if (assemblyLoc != null)
            {
                String currentDirectory = assemblyLoc.Substring(0, assemblyLoc.LastIndexOf(Path.DirectorySeparatorChar) + 1);
                pluginDirectory = Path.Combine(currentDirectory, pluginRelativePath);
            }
            if (!pluginDirectory.EndsWith(Path.DirectorySeparatorChar.ToString()))
                pluginDirectory = pluginDirectory + Path.DirectorySeparatorChar;

            localLoader = new LocalLoader(pluginDirectory);

            // Add the most common references since plugin authors can't control which references they
            // use in scripts.  Adding a reference later that already exists does nothing.
            AddReference("Accessibility.dll");
            AddReference("Microsoft.Vsa.dll");
            AddReference("System.Configuration.Install.dll");
            AddReference("System.Data.dll");
            AddReference("System.Design.dll");
            AddReference("System.DirectoryServices.dll");
            AddReference("System.Drawing.Design.dll");
            AddReference("System.Drawing.dll");
            AddReference("System.EnterpriseServices.dll");
            AddReference("System.Management.dll");
            AddReference("System.Runtime.Remoting.dll");
            AddReference("System.Runtime.Serialization.Formatters.Soap.dll");
            AddReference("System.Security.dll");
            AddReference("System.ServiceProcess.dll");
            AddReference("System.Web.dll");
            AddReference("System.Web.RegularExpressions.dll");
            AddReference("System.Web.Services.dll");
            AddReference("System.Windows.Forms.Dll");
            AddReference("System.XML.dll");
        }
        #endregion

        #endregion

        #region Destructor
        /// <summary>
        /// The destructor for the plugin manager
        /// </summary>
        ~PluginManager()
        {
            Stop();
        }
        #endregion

        #region Event Handlers

        #region fileSystemWatcher_Changed
        /// <summary>
        /// Handles changes to the file system in the plugin directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            changeTime = DateTime.Now + new TimeSpan(0, 0, 10);
        }
        #endregion

        #endregion

        #region Methods

        #region public void Start()
        /// <summary>
        /// Initializes the plugin manager
        /// </summary>
        public void Start()
        {
            started = true;
            if (autoReload)
            {
                fileSystemWatcher = new FileSystemWatcher(pluginDirectory);
                fileSystemWatcher.EnableRaisingEvents = true;
                fileSystemWatcher.Changed += fileSystemWatcher_Changed;
                fileSystemWatcher.Deleted += fileSystemWatcher_Changed;
                fileSystemWatcher.Created += fileSystemWatcher_Changed;

                pluginReloadThread = new Thread(ReloadThreadLoop);
                pluginReloadThread.Start();
            }
            ReloadPlugins();
        }
        #endregion

        #region protected void ReloadThreadLoop()
        /// <summary>
        /// The main updater thread loop.
        /// </summary>
        protected void ReloadThreadLoop()
        {
            if (!started) throw new InvalidOperationException("PluginManager has not been started.");
            DateTime invalidTime = new DateTime(0);
            while (!beginShutdown)
            {
                if (changeTime != invalidTime && DateTime.Now > changeTime) ReloadPlugins();
                Thread.Sleep(500);
            }
            active = false;
        }
        #endregion

        #region public void ReloadPlugins()
        /// <summary>
        /// Reloads all plugins in the plugins directory
        /// </summary>
        public void ReloadPlugins()
        {
            if (!started) throw new InvalidOperationException("PluginManager has not been started.");
            lock (lockObject)
            {
                localLoader.Unload();
                localLoader = new LocalLoader(pluginDirectory);
                LoadUserAssemblies();
                changeTime = new DateTime(0);
                if (PluginsReloaded != null) PluginsReloaded(this, new EventArgs());
            }
        }
        #endregion

        #region protected void LoadUserAssemblies()
        /// <summary>
        /// Loads all user created plugin assemblies
        /// </summary>
        protected void LoadUserAssemblies()
        {
            if (!started) throw new InvalidOperationException("PluginManager has not been started.");
            compilerErrors = new ArrayList();
            DirectoryInfo directory = new DirectoryInfo(pluginDirectory);
            if (pluginSources == PluginSourceEnum.DynamicAssemblies ||
                pluginSources == PluginSourceEnum.Both)
                foreach (FileInfo file in directory.GetFiles("*.dll"))
                    try { localLoader.LoadAssembly(file.FullName); }
                    catch (PolicyException e)
                    { throw new PolicyException(String.Format("«„ﬂ«‰ »«“ ﬂ—œ‰ {0} ÊÃÊœ ‰œ«—œ", file.Name), e); }
            if (pluginSources == PluginSourceEnum.DynamicCompilation ||
                pluginSources == PluginSourceEnum.Both)
            {
                // Load all C# scripts
                ArrayList scriptList = new ArrayList();
                foreach (FileInfo file in directory.GetFiles("*.cs")) scriptList.Add(file.FullName);
                LoadScriptBatch((String[])scriptList.ToArray(typeof(String)));
                // Load all VB.net scripts
                scriptList = new ArrayList();
                foreach (FileInfo file in directory.GetFiles("*.vb")) scriptList.Add(file.FullName);
                LoadScriptBatch((String[])scriptList.ToArray(typeof(String)));
                // Load all JScript scripts
                scriptList = new ArrayList();
                foreach (FileInfo file in directory.GetFiles("*.js")) scriptList.Add(file.FullName);
                LoadScriptBatch((String[])scriptList.ToArray(typeof(String)));
            }
        }
        #endregion

        #region private void LoadScriptBatch(String[] filenames)
        /// <summary>
        /// Batch loads a set of scripts of the same language
        /// </summary>
        /// <param name="filenames">The list of script filenames to load</param>
        private void LoadScriptBatch(String[] filenames)
        {
            if (filenames.Length > 0)
            {
                IList errors = localLoader.LoadScripts(filenames, references);
                if (errors.Count > 0)
                {
                    // If there are compiler errors record them and the file they occurred in
                    foreach (String error in errors) compilerErrors.Add(error);
                    if (!ignoreErrors)
                    {
                        StringBuilder aggregateErrorText = new StringBuilder();
                        foreach (String error in errors) aggregateErrorText.Append(error + "\r\n");
                        throw new InvalidOperationException("\r\nCompiler error(s) have occurred:\r\n\r\n " + 
                            aggregateErrorText + "\r\n");
                    }
                }
            }
        }
        #endregion

        #region public void AddReference(String referenceToDll)
        /// <summary>
        /// Adds a reference to the plugin manager to be used when compiling scripts
        /// </summary>
        /// <param name="referenceToDll">The reference to the dll to add</param>
        public void AddReference(String referenceToDll)
        {
            if (!references.Contains(referenceToDll)) references.Add(referenceToDll);
        }
        #endregion

        #region public String[] GetSubClasses(String baseClass)
        /// <summary>
        /// Retrieves the type objects for all subclasses of the given type within the loaded plugins.
        /// </summary>
        /// <param name="baseClass">The base class</param>
        /// <returns>All subclases</returns>
        public String[] GetSubClasses(String baseClass)
        {
            if (!started) throw new InvalidOperationException("PluginManager has not been started.");
            return localLoader.GetSubclasses(baseClass);
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
            if (!started) throw new InvalidOperationException("PluginManager has not been started.");
            return localLoader.ManagesType(typeName);
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
            if (!started) throw new InvalidOperationException("PluginManager has not been started.");
            return localLoader.GetStaticPropertyValue(typeName, propertyName);
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
            if (!started) throw new InvalidOperationException("PluginManager has not been started.");
            return localLoader.CallStaticMethod(typeName, methodName, methodParams);
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
            if (!started) throw new InvalidOperationException("PluginManager has not been started.");
            return localLoader.CreateInstance(typeName, bindingFlags, CtorParams);
        }
        #endregion

        #region public void Stop()
        /// <summary>
        /// Shuts down the plugin manager
        /// </summary>
        public void Stop()
        {
            try
            {
                beginShutdown = true;
                started = false;
                pluginReloadThread.Abort();
                pluginReloadThread = null;
                AppDomain.Unload(AppDomain.CurrentDomain);
                localLoader.Unload();
                localLoader = null;
            }
            // ReSharper disable EmptyGeneralCatchClause
            catch { }
            // ReSharper restore EmptyGeneralCatchClause
        }
        #endregion

        #endregion

    }
}