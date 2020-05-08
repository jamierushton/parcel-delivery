using ParcelDelivery.Abstractions;

namespace ParcelDelivery.ConsoleApp.Handlers
{
    public class RegularHandler : AbstractHandler<Parcel, ProcessorResult>
    {
        public override Attempt<ProcessorResult> Handle(Parcel parcel)
        {
            if (parcel.Weight < 10)
            {
                return Attempt<ProcessorResult>.Succeed(ProcessorResult.Sent(GetType(), parcel));
            }

            return base.Handle(parcel);
        }
    }
}