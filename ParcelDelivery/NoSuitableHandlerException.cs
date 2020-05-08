using System;
using System.Runtime.Serialization;

namespace ParcelDelivery
{
    [Serializable]
    public class NoSuitableHandlerException : Exception
    {
        public NoSuitableHandlerException()
        {
        }

        public NoSuitableHandlerException(string message) : base(message)
        {
        }

        public NoSuitableHandlerException(string message, Exception inner) : base(message, inner)
        {
        }

        protected NoSuitableHandlerException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}