using System;
using System.Runtime.Serialization;

namespace HospitalEmployees.Exceptions
{
    [Serializable]
    internal class BadSpecializationException : Exception
    {
        public BadSpecializationException()
        {
            Console.WriteLine("Doctors can have only one of those four specializations: cardiologist, urologist, neurologist, laryngologist.");
        }

        public BadSpecializationException(string message) : base(message)
        {
        }

        public BadSpecializationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BadSpecializationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}