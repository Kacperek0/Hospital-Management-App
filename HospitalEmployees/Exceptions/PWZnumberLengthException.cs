using System;
using System.Runtime.Serialization;

namespace HospitalEmployees.Exceptions
{
    [Serializable]
    internal class PWZnumberLengthException : Exception
    {
        public PWZnumberLengthException()
        {
            Console.WriteLine("PWZ number has to be 7 digits long.");
        }

        public PWZnumberLengthException(string message) : base(message)
        {
        }

        public PWZnumberLengthException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PWZnumberLengthException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}