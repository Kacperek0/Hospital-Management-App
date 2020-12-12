using System;
using System.Runtime.Serialization;

namespace HospitalEmployees.Exceptions
{
    [Serializable]
    internal class AddShiftFailureException : Exception
    {
        public AddShiftFailureException()
        {
        }

        public AddShiftFailureException(string message) : base(message)
        {
        }

        public AddShiftFailureException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AddShiftFailureException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}