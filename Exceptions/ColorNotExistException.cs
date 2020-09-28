using System;
using System.Runtime.Serialization;

namespace assessment_server_side.Exceptions
{
    [Serializable]
    public class ColorNotExistException : Exception
    {
        public ColorNotExistException()
        {
        }

        public ColorNotExistException(string colorname) :
            base("given color name '" + colorname + "' doesn't exist in our database/csv")
        {
        }

        public ColorNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ColorNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}