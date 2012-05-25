using System;
using System.Runtime.Serialization;

namespace Ata
{
    [Serializable]
    public class AtaException : Exception
    {
        public AtaException() : this(null)
        {
        }

        public AtaException(AtaError error) : this(error.ToString())
        {
        }

        public AtaException(string message) : this(message, null)
        {
        }

        public AtaException(AtaError error, string message) : this(message, null)
        {
        }

        public AtaException(string message, Exception innerException) : this(AtaError.None, message, innerException)
        {
        }

        public AtaException(AtaError error, string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AtaException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public static Exception CreateException(AtaError error)
        {
            return new AtaException(error);
        }
    }
}