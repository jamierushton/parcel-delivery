using ParcelDelivery.Abstractions;

namespace ParcelDelivery.ConsoleApp.Handlers
{
    public class MailHandler : AbstractHandler<Parcel, ProcessorResult>
    {
        public override Attempt<ProcessorResult> Handle(Parcel parcel)
        {
            if (parcel.Weight < 1)
            {
                return Attempt<ProcessorResult>.Succeed(ProcessorResult.Sent(GetType(), parcel));
            }

            return base.Handle(parcel);
        }
    }
}