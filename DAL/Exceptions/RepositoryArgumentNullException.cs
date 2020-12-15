using System;
using System.Runtime.Serialization;

namespace DAL.Exceptions
{
    [Serializable]
    public class RepositoryArgumentNullException : ArgumentException
    {
        public RepositoryArgumentNullException()
        {
        }

        public RepositoryArgumentNullException(string message, string paramName) : base(message, paramName)
        {
        }

        public RepositoryArgumentNullException(string message, string paramName, Exception inner) : base(message, paramName, inner)
        {
        }

        protected RepositoryArgumentNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}