using System;
using System.Runtime.Serialization;

namespace HospitalApp.Exceptions
{
    [Serializable]
    internal class InternalDataErrorException : Exception
    {
        public InternalDataErrorException()
        {
            Console.WriteLine("Critical error in loaded data! Please check the file!");
        }

        public InternalDataErrorException(string message) : base(message)
        {
        }

        public InternalDataErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InternalDataErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}