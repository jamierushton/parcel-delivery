namespace ParcelDelivery.Tests.Stubs
{
    public class StubSuccessHander : StubHander
    {
        public override Attempt<ProcessorResult> Handle(Parcel obj)
        {
            return Attempt<ProcessorResult>.Succeed(ProcessorResult.Sent(GetType(), obj));
        }
    }
}