#region using
using System;
using System.EnterpriseServices;
using System.Threading;
#endregion

namespace Negar.ComHelper
{
    public partial class ComHelperPooled
    {
        private class Task : IServiceCall
        {

            #region Fields
            private readonly ComHelperPooled _container;

            // can be a ThreadStart or ParameterizedThreadStart delegate
            private readonly object _operation;
            #endregion

            #region Ctor
            public Task(ComHelperPooled container, object operation)
            {
                _container = container;
                _operation = operation;
            }
            #endregion

            #region Methods

            #region public void OnCall()
            public void OnCall()
            {
                Exception ex = null;
                try
                {
                    if (_operation is ParameterizedThreadStart)
                    {
                        object arg = _container._operations[_operation];
                        ((ParameterizedThreadStart)_operation)(arg);
                    }
                    else ((ThreadStart)_operation)();
                }
                catch (Exception e) { ex = e; }
                finally
                {
                    AutoResetEvent hnd = null;
                    if (_container._locks.ContainsKey(_operation))
                        hnd = _container._locks[_operation];
                    if (hnd != null) hnd.Set();
                }
                OperationCompletionDelegate cb = _container._callbacks.ContainsKey(_operation)
                        ? _container._callbacks[_operation] : null;
                // callback
                Delegate p = _operation as Delegate;
                if (cb != null)
                {
                    if (p != null)
                    {
                        OperationCompletionMetadata data = new OperationCompletionMetadata(p.Target, p.Method, ex);
                        if (_container._execAsyncCallback) cb.BeginInvoke(data, null, null);
                        else cb.Invoke(data);
                    }
                }
            }
            #endregion

            #endregion

        }
    }
}