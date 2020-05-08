using ParcelDelivery.Abstractions;

namespace ParcelDelivery.Tests.Stubs
{
    public class StubHander : AbstractHandler<Parcel, ProcessorResult>
    {
        //  No override will default to the NoSuitableHandlerException
    }
}