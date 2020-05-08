using ParcelDelivery.Abstractions;

namespace ParcelDelivery.ConsoleApp.Handlers
{
    public class InsuranceHandler : AbstractHandler<Parcel, ProcessorResult>
    {
        public override Attempt<ProcessorResult> Handle(Parcel parcel)
        {
            switch (parcel.Approved)
            {
                case null when parcel.Value >= 1000:
                    return Attempt<ProcessorResult>.Fail(ProcessorResult.RequiresApprovalBeforeSending(GetType(), parcel));
                case false:
                    return Attempt<ProcessorResult>.Fail(null, new ApprovalDeclinedException());
                default:
                    return base.Handle(parcel);
            }
        }
    }
}