using System;
using System.Runtime.Serialization;

namespace ParcelDelivery
{
    [Serializable]
    public class ApprovalDeclinedException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public ApprovalDeclinedException()
        {
        }

        public ApprovalDeclinedException(string message) : base(message)
        {
        }

        public ApprovalDeclinedException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ApprovalDeclinedException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}