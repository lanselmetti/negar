#region using

using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Threading;
#endregion

namespace Negar.ComHelper
{
    /// <summary>
    /// A task scheduling component that runs tasks in a Single Threaded Apartment
    /// </summary>
    /// <remarks>
    /// This class is an enhancement over <see cref="ComHelper"/>.
    /// It uses the COM+ STA thread pool to schedule the 
    /// registered tasks in background STA threads.
    /// </remarks>
    public partial class ComHelperPooled : ComHelper
    {

        #region Fields
        private readonly Dictionary<Object, Task> _tasks;
        private bool _invokeAsynchronously;
        #endregion
        
        #region Properties

        #region Boolean InvokeAsynchronously
        /// <summary>
        /// If true, registered tasks are invoked asynchronously
        /// </summary>
        /// <remarks>
        /// By default, registered tasks are invoked asynchronously.
        /// If the value is explicitly set to false, tasks are invoked
        /// sequentially in synchronous calls.
        /// </remarks>
        public Boolean InvokeAsynchronously
        {
            get { return _invokeAsynchronously; }
            set { _invokeAsynchronously = value; }
        }
        #endregion

        #endregion

        #region Ctor
        public ComHelperPooled()
        {
            _tasks = new Dictionary<object, Task>();
            _invokeAsynchronously = true;
        }
        #endregion

        #region Methods

        #region public override void Execute()
        /// <summary>
        /// Entry point to start executing the registered task(s).
        /// </summary>
        /// <remarks>
        /// Depending on the mode set in <see cref="InvokeAsynchronously"/>
        /// ComHelperPooled runs the tasks in an STA thread pool.
        /// </remarks>
        public override void Execute()
        {
            InitOperations();
            InvokeDelegates();
        }
        #endregion

        #region protected override void InitOperations()
        /// <summary>
        /// This method is called within <see cref="Execute"/>. 
        /// It sets up the wait handles for each registered operation.
        /// </summary>
        /// <remarks>
        /// Wait handles are setup only after the call to 
        /// <see cref="Execute"/>x.
        /// One can wait over operations only after invoking 
        /// <see cref="Execute"/>.
        /// </remarks>
        protected override void InitOperations()
        {
            foreach (object operation in _operations.Keys)
            {
                _locks[operation] = new AutoResetEvent(false);
                _tasks[operation] = new Task(this, operation);
            }
        }
        #endregion

        #region protected override void InvokeDelegates()
        /// <summary>
        /// This method is called within <see cref="Execute"/>. 
        /// It invokes the registered tasks using threads from the 
        /// STA thread pool.
        /// </summary>
        protected override void InvokeDelegates()
        {
            foreach (Task task in _tasks.Values)
            {
                Activity a = CreateActivity();
                if (_invokeAsynchronously)
                    a.AsynchronousCall(task);
                else a.SynchronousCall(task);
            }
        }
        #endregion

        #region private static Activity CreateActivity()
        private static Activity CreateActivity()
        {
            var cfg = new ServiceConfig();
            cfg.ThreadPool = ThreadPoolOption.STA;
            return new Activity(cfg);
        }
        #endregion

        #endregion

    }
}