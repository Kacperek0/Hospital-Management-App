using System;
using System.Runtime.Serialization;

namespace HospitalEmployees.Exceptions
{
    [Serializable]
    internal class PeselLengthException : Exception
    {
        public PeselLengthException()
        {
            Console.WriteLine("PESEL has to be 9 digits long.");
        }

        public PeselLengthException(string message) : base(message)
        {
        }

        public PeselLengthException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PeselLengthException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}