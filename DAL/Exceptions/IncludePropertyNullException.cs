using System;
using System.Runtime.Serialization;

namespace DAL.Exceptions
{
    [Serializable]
    class IncludePropertyNullException : Exception
    {
        public IncludePropertyNullException()
        {
        }

        public IncludePropertyNullException(string message) : base(message)
        {
        }

        public IncludePropertyNullException(string message, Exception inner) : base(message, inner)
        {
        }

        protected IncludePropertyNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}