using System;
using System.Runtime.Serialization;

namespace assessment_server_side.Exceptions
{
    [Serializable]
    public class PersonNotExistException : Exception
    {
        public PersonNotExistException() :
            base("no person found")

        {
        }

        public PersonNotExistException(int id) :
            base("no person found with given id=" + id)
        {
        }

        public PersonNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PersonNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}