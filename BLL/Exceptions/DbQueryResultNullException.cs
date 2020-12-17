using System;
using System.Runtime.Serialization;

namespace BLL.Exceptions
{
        [Serializable]
        public class DbQueryResultNullException : Exception
        {
                public DbQueryResultNullException()
                {
                }

                public DbQueryResultNullException(string message) : base(message)
                {
                }

                public DbQueryResultNullException(string message, Exception inner) : base(message, inner)
                {
                }

                protected DbQueryResultNullException(SerializationInfo info, StreamingContext context) : base(info, context)
                {
                }
        }
}