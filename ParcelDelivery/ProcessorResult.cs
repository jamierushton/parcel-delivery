using System;

namespace ParcelDelivery
{
    public class ProcessorResult
    {
        private ProcessorResult(Type handlerType,
                                Parcel parcel,
                                bool requiresApproval = false)
        {
            HandlerType = handlerType;
            HandlerName = handlerType.Name;

            Parcel = parcel;

            RequiresApproval = requiresApproval;
        }

        public Type HandlerType { get; }
        public string HandlerName { get; }
        public Parcel Parcel { get; }
        public bool RequiresApproval { get; }


        public static ProcessorResult RequiresApprovalBeforeSending(Type handlerType, Parcel parcel)
        {
            return new ProcessorResult(handlerType, parcel, requiresApproval: true);
        }

        public static ProcessorResult Sent(Type handlerType, Parcel parcel)
        {
            return new ProcessorResult(handlerType, parcel);
        }
    }
}