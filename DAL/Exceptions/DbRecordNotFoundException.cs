using System;
using System.Runtime.Serialization;

namespace DAL.Exceptions
{
    [Serializable]
    public class DbRecordNotFoundException : ArgumentException
    {
        public DbRecordNotFoundException()
        {
        }

        public DbRecordNotFoundException(string message, string paramName) : base(message, paramName)
        {
        }

        public DbRecordNotFoundException(string message, string paramName, Exception inner) : base(message, paramName, inner)
        {
        }

        protected DbRecordNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}