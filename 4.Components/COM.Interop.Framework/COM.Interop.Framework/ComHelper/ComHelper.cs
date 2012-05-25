#region using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
#endregion

namespace Negar.ComHelper
{
    /// <summary>
    /// كلاسی برای مدیریت همزمانی در كامپوننت های كام
    /// </summary>
    public class ComHelper
    {

        #region Delegates
        /// <summary>
        /// Callbacks may be optionally registered which are invoked after
        /// a task has been executed. Callbacks are registered as a 
        /// delegate of the type <see cref="OperationCompletionDelegate"/>.
        /// </summary>
        /// <param name="metadata"></param>
        public delegate void OperationCompletionDelegate(OperationCompletionMetadata metadata);
        #endregion

        #region Fields

        #region protected Dictionary<Object, OperationCompletionDelegate> _callbacks
        /// <summary>
        /// Contains callbacks (if specified) for each registered operation
        /// </summary>
        protected Dictionary<Object, OperationCompletionDelegate> _callbacks;
        #endregion

        #region protected Boolean _execAsyncCallback
        /// <summary>
        /// Callback execution mode
        /// </summary>
        protected Boolean _execAsyncCallback;
        #endregion

        #region protected Dictionary<Object, AutoResetEvent> _locks
        /// <summary> Contains wait handles for each registered
        /// operation</summary>
        protected Dictionary<Object, AutoResetEvent> _locks;
        #endregion

        #region protected Hashtable _operations
        /// <summary> Contains the methods to be executed in STA and their
        /// corresponding parameters (optional)</summary>
        protected Hashtable _operations;

        /// <summary></summary>
        public ComHelper()
        {
            _operations = new Hashtable();
            _callbacks = new
                Dictionary<Object, OperationCompletionDelegate>();
            _locks = new Dictionary<object, AutoResetEvent>();
        }
        #endregion

        #endregion

        #region Properties

        #region Boolean ExecAsyncCallback
        /// <summary>
        /// If true OperationCompletionDelegate callback is invoked
        /// asynchronously on an MTA thread. If false, the callback is 
        /// executed synchronously on the same STA thread.
        /// </summary>
        public Boolean ExecAsyncCallback
        {
            get { return _execAsyncCallback; }
            set { _execAsyncCallback = value; }
        }
        #endregion

        #region protected virtual AutoResetEvent this[Object operation]
        /// <summary>
        /// Provides access to the wait handle for the specified task.
        /// </summary>
        /// <remarks>
        /// Each registered task has a corresponding <see cref="WaitHandle"/>
        /// on which the client can wait. However, wait handles are 
        /// created only after Execute is invoked and not at the time 
        /// when  Register overloads are invoked.
        /// </remarks>
        /// <param name="operation">The <see cref="ThreadStart"/> or 
        /// <see cref="ParameterizedThreadStart"/> delegate to the task 
        /// of interest.
        /// </param>
        /// <returns></returns>
        protected virtual AutoResetEvent this[Object operation]
        {
            get { return _locks.ContainsKey(operation) ? _locks[operation] : null; }
        }
        #endregion

        #endregion

        #region Methods

        #region public void Register(...)
        /// <overloads>
        /// <summary>
        /// Register tasks to be executed on the STA thread.
        /// </summary>
        /// <remarks>
        /// Typically the .NET code blocks methods (tasks) are
        /// registered with the component using one of the 
        /// Register overloads.
        /// This pattern is used to register multiple tasks and execute 
        /// them as a batch in STA. In this case after calls to 
        /// Register the Execute()
        /// method is invoked without parameters.
        /// </remarks>
        /// </overloads>
        /// <param name="operation">The task (delegate to a method with 
        /// <see cref="Object"/> parameter).</param>
        /// <param name="args">The method parameter.</param>
        /// <param name="onOperationCompleteCallback">The callback
        /// to be executed after the task is run.</param>        
        public void Register(ParameterizedThreadStart operation, object args,
                             OperationCompletionDelegate onOperationCompleteCallback)
        {
            RegisterInternal(operation, args, onOperationCompleteCallback);
        }
        #endregion

        #region public void Register(ParameterizedThreadStart operation, object args)
        /// <summary>
        /// Register a task to be executed on the STA thread.
        /// </summary>
        /// <param name="operation">The task (delegate to a method with 
        /// <see cref="Object"/> parameter).
        /// </param>
        /// <param name="args">The method parameter.</param>
        public void Register(ParameterizedThreadStart operation, object args)
        {
            Register(operation, args, null);
        }
        #endregion

        #region public void Register( ThreadStart operation, OperationCompletionDelegate onOperationCompleteCallback)
        /// <summary>
        /// Register a task to be executed on the STA thread.
        /// </summary>
        /// <param name="operation">The task (delegate to a void method).</param>
        /// <param name="onOperationCompleteCallback">The callback
        /// to be executed after the task is run.</param>
        public void Register(ThreadStart operation, OperationCompletionDelegate onOperationCompleteCallback)
        {
            RegisterInternal(operation, null, onOperationCompleteCallback);
        }
        #endregion

        #region public void Register(ThreadStart operation)
        /// <summary>
        /// Register a task to be executed on the STA thread.
        /// </summary>
        /// <param name="operation">The task (delegate to a void method).</param>
        public void Register(ThreadStart operation)
        {
            Register(operation, null);
        }
        #endregion

        #region public void Unregister(ParameterizedThreadStart operation)
        /// <overloads>
        /// <summary>
        /// Used to unregister previously registered tasks.
        /// </summary>
        /// </overloads>
        public void Unregister(ParameterizedThreadStart operation)
        {
            UnRegisterInternal(operation);
        }
        #endregion

        #region public void Unregister(ThreadStart operation)
        public void Unregister(ThreadStart operation)
        {
            UnRegisterInternal(operation);
        }
        #endregion

        #region private void UnRegisterInternal(Object operation)
        private void UnRegisterInternal(Object operation)
        {
            if (operation == null) throw new ArgumentNullException("operation");
            _operations.Remove(operation);
            _callbacks.Remove(operation);
        }
        #endregion

        #region public void Reset()
        /// <summary>
        /// Restore to default state by clearing previous state.
        /// </summary>
        public void Reset()
        {
            _operations.Clear();
            _callbacks.Clear();
            _locks.Clear();
        }
        #endregion

        #region public virtual void WaitOnOperation(Object operation)
        /// <summary>
        /// Enables the client to wait on a specified operation till
        /// it has been executed by the STA thread.
        /// </summary>
        /// <remarks>
        /// Each registered task has a corresponding 
        /// <see cref="WaitHandle"/> on which the client can wait. 
        /// However, wait handles are created only after 
        /// Execute is invoked and not at the time when
        /// Register overloads are invoked.
        /// </remarks>
        /// <param name="operation">The <see cref="ThreadStart"/> or 
        /// <see cref="ParameterizedThreadStart"/> delegate to the task 
        /// of interest.</param>
        public virtual void WaitOnOperation(Object operation)
        {
            WaitHandle wait = this[operation];
            if (wait != null) wait.WaitOne();
            else
                throw new TimeoutException(
                    @"The operation has not yet begun. 
                Please try again after a few milliseconds to wait on the operation.");
        }
        #endregion

        #region public virtual void WaitOnAllOperations()
        /// <summary>
        /// Enables the client to wait till all registered tasks have 
        /// been executed by the STA thread.
        /// </summary>
        /// <remarks>
        /// Each registered task has a corresponding 
        /// <see cref="WaitHandle"/> on which the client can wait. 
        /// However, wait handles are created only after 
        /// Execute is invoked and not at the time when
        ///  Register overloads are invoked.
        /// </remarks>
        public virtual void WaitOnAllOperations()
        {
            var locks = new AutoResetEvent[_locks.Count];
            _locks.Values.CopyTo(locks, 0);
            WaitHandle.WaitAll(locks);
        }
        #endregion

        #region private void RegisterInternal(...)
        private void RegisterInternal(Object operation, Object args,
                                      OperationCompletionDelegate onOperationCompleteCallback)
        {
            if (operation == null)
                throw new ArgumentNullException("operation", "The delegate to register cannot be null");
            _operations[operation] = args;
            if (onOperationCompleteCallback != null)
                _callbacks[operation] = onOperationCompleteCallback;
        }
        #endregion

        #region protected virtual void InitOperations()
        /// <summary>
        /// This method is called within Execute. 
        /// It sets up the wait handles for each registered operation.
        /// </summary>
        /// <remarks>
        /// Wait handles are setup only after the call to 
        /// Execute. One can wait over operations only 
        /// after invoking Execute.
        /// </remarks>
        protected virtual void InitOperations()
        {
            foreach (object operation in _operations.Keys)
                _locks[operation] = new AutoResetEvent(false);
        }
        #endregion

        #region protected virtual void InvokeDelegates()
        /// <summary>
        /// Invoke the registered task(s).
        /// </summary>
        /// <remarks>
        /// This method is called within Execute. 
        /// The base implementation of this virtual method 
        /// runs in a foreground STA thread. It invokes the registered 
        /// tasks on this STA thread.
        /// The foreground thread is not killed when main thread exits
        /// </remarks>
        protected virtual void InvokeDelegates()
        {
            foreach (DictionaryEntry operation in _operations)
            {
                object d = operation.Key;
                Exception ex;
                try
                {
                    if (d is ParameterizedThreadStart)
                        (d as ParameterizedThreadStart)(operation.Value);
                    else ((ThreadStart)d)();
                    ex = null;
                }
                catch (Exception e)
                {
                    ex = e;
                }
                finally
                {
                    AutoResetEvent wait = this[d];
                    if (wait != null) wait.Set();
                }
                OperationCompletionDelegate cb =
                    _callbacks.ContainsKey(d) ? _callbacks[d] : null;
                // callback
                Delegate p = d as Delegate;
                if (cb != null)
                {
                    if (p != null)
                    {
                        OperationCompletionMetadata data = new OperationCompletionMetadata(p.Target, p.Method, ex);
                        if (_execAsyncCallback) cb.BeginInvoke(data, null, null);
                        else cb.Invoke(data);
                    }
                }
            }
        }
        #endregion

        #region public virtual void Execute()
        /// <overloads>
        /// <summary>
        /// Invoke the scheduled tasks by calling Execute
        /// </summary>
        /// </overloads>
        /// <remarks>
        /// This overload of Execute(void) is to be called AFTER 
        /// registering one or more tasks via a call to one of the Register overloads.
        /// </remarks>
        public virtual void Execute()
        {
            InitOperations();
            ApartmentState apt = Thread.CurrentThread.GetApartmentState();
            if (apt != ApartmentState.STA)
            {
                Thread t = new Thread(InvokeDelegates);
                bool res = t.TrySetApartmentState(ApartmentState.STA);
                if (res)
                {
                    t.Start();
                    return;
                }
            }
            InvokeDelegates();
        }
        #endregion

        #region public void Execute(ThreadStart methodWithoutArgs)
        /// <summary>
        /// Invoke the task (method with a void parameter)
        /// </summary>
        /// <remarks>
        /// This method is intended to directly execute the specified
        /// task without the need to a prior Register call.
        /// However, if Register has been called before,
        /// the specified task in this Execute overload will be queued
        /// along with earlier tasks that were registered. 
        /// </remarks>
        /// <param name="methodWithoutArgs">Delegate to a method with 
        /// void parameter</param>
        public void Execute(ThreadStart methodWithoutArgs)
        {
            Execute(methodWithoutArgs, null);
        }
        #endregion

        #region public void Execute(...)
        /// <summary>
        /// Invoke the task (method with a void parameter)
        /// </summary>
        /// <remarks>
        /// This method is intended to directly execute the specified
        /// task without the need to a prior Register call.
        /// However, if Register has been called before,
        /// the specified task in this Execute overload will be queued
        /// along with earlier tasks that were registered. 
        /// </remarks>
        /// <param name="methodWithoutArgs">Delegate to a method with 
        /// void parameter</param>
        /// <param name="onMethodCompleted">Callback to be invoked
        /// on task completion.</param>
        public void Execute(ThreadStart methodWithoutArgs,
                            OperationCompletionDelegate onMethodCompleted)
        {
            Register(methodWithoutArgs, onMethodCompleted);
            Execute();
        }
        #endregion

        #region public void Execute(ParameterizedThreadStart methodWithParams, object methodArgs)
        /// <summary>
        /// Invoke the task (method with a void parameter)
        /// </summary>
        /// <remarks>
        /// This method is intended to directly execute the specified
        /// task without the need to a prior Register call.
        /// However, if Register has been called before,
        /// the specified task in this Execute overload will be queued
        /// along with earlier tasks that were registered. 
        /// </remarks>
        /// <param name="methodWithParams">Delegate to a method with 
        /// <see cref="Object"/> parameter.</param>
        /// <param name="methodArgs">The parameter to the task(method).</param>
        public void Execute(ParameterizedThreadStart methodWithParams, object methodArgs)
        {
            Execute(methodWithParams, methodArgs, null);
        }
        #endregion

        #region public void Execute(...)
        /// <summary>
        /// Invoke the task (method with a void parameter)
        /// </summary>
        /// <remarks>
        /// This method is intended to directly execute the specified
        /// task without the need to a prior Register call.
        /// However, if  Register has been called before,
        /// the specified task in this Execute overload will be queued
        /// along with earlier tasks that were registered. 
        /// </remarks>
        /// <param name="methodWithParams">Delegate to a method with 
        /// <see cref="Object"/> parameter.</param>
        /// <param name="methodArgs">The parameter to the task(method).</param>
        /// <param name="onMethodCompleted">Callback to be invoked
        /// on task completion.</param>
        public void Execute(ParameterizedThreadStart methodWithParams,
                            Object methodArgs, OperationCompletionDelegate onMethodCompleted)
        {
            Register(methodWithParams, methodArgs, onMethodCompleted);
            Execute();
        }
        #endregion

        #endregion

    }
}