#region using
using System;
using System.Reflection;
#endregion

namespace Negar.ComHelper
{
    /// <summary>
    /// Contains state information on the results of execution of an operation. 
    /// </summary>
    /// <remarks>
    /// State information includes the object on which the method was
    /// invoked, exceptions (if any) and method information.
    /// </remarks>
    public struct OperationCompletionMetadata
    {

        #region Fields
        public Exception exception;
        /// <summary>Metadata about the operation that was invoked</summary>
        public MethodInfo method;
        /// <summary> State of the object after operation </summary>
        public object state;

        #endregion

        #region Ctors

        #region public OperationCompletionMetadata(object state, MethodInfo m, Exception ex)
        /// <overloads>
        ///     <summary> 
        ///     Constructor overloads
        ///     </summary>
        /// </overloads>
        public OperationCompletionMetadata(object state, MethodInfo m, Exception ex)
        {
            this.state = state;
            method = m;
            exception = ex;
        }
        #endregion

        #region public OperationCompletionMetadata(object state, MethodInfo m) : this(state, m, null)
        /// <summary></summary>
        public OperationCompletionMetadata(object state, MethodInfo m)
            : this(state, m, null)
        {
        }
        #endregion

        #region public OperationCompletionMetadata(object state) : this(state, null)
        public OperationCompletionMetadata(object state) : this(state, null)
        {
        }
        #endregion

        #region public OperationCompletionMetadata(MethodInfo m) : this(null, m)
        public OperationCompletionMetadata(MethodInfo m) : this(null, m)
        {
        }
        #endregion

        #endregion

    }
}