using System;
using ParcelDelivery.Abstractions;
using ParcelDelivery.ConsoleApp.Handlers;

namespace ParcelDelivery.ConsoleApp
{
    public class DefaultWorkflow : IProcessorCreator<Parcel, ProcessorResult>
    {
        public IHandler<Parcel, ProcessorResult> Create()
        {
            var handler = new InsuranceHandler();

            handler.SetNext(new MailHandler())
                   .SetNext(new RegularHandler())
                   .SetNext(new HeavyHandler());

            return handler;
        }
    }
}