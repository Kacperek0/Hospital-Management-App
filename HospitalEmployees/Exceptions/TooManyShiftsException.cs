using System;
using System.Runtime.Serialization;

namespace HospitalEmployees.Exceptions
{
    [Serializable]
    internal class TooManyShiftsException : Exception
    {
        public TooManyShiftsException()
        {
        }

        public TooManyShiftsException(string message) : base(message)
        {
        }

        public TooManyShiftsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TooManyShiftsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}