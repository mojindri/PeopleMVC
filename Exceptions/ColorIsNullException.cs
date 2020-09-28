using System;
using System.Runtime.Serialization;

namespace assessment_server_side.Exceptions
{
    [Serializable]
    public class ColorIsNullException : Exception
    {
        public ColorIsNullException() : base("Color is null.")
        {
        }

        public ColorIsNullException(string message) : base(message)
        {
        }

        public ColorIsNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ColorIsNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}