using System;
using System.Runtime.Serialization;

namespace assessment_server_side.Exceptions
{
    [Serializable]
    public class NoPeopleForUpdateException : Exception
    {
        public NoPeopleForUpdateException():base("No People exist to update.")
        {
        
        }

        public NoPeopleForUpdateException(string message) : base(message)
        {
        }

        public NoPeopleForUpdateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoPeopleForUpdateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}