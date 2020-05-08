using ParcelDelivery.Abstractions;

namespace ParcelDelivery.ConsoleApp.Handlers
{
    public class HeavyHandler : AbstractHandler<Parcel, ProcessorResult>
    {
        public override Attempt<ProcessorResult> Handle(Parcel parcel)
        {
            return Attempt<ProcessorResult>.Succeed(ProcessorResult.Sent(GetType(), parcel));;
        }
    }
}