using System;
using Microsoft.Extensions.Logging;
using ParcelDelivery.Abstractions;
using ParcelDelivery.Extensions;

namespace ParcelDelivery
{
    public sealed class ParcelProcessor : IParcelProcessor
    {
        private readonly ILogger<ParcelProcessor> _logger;
        private readonly IProcessorCreator<Parcel, ProcessorResult> _processorCreator;
        private readonly IApprovalProvider _approvalProvider;

        public ParcelProcessor(
            ILogger<ParcelProcessor> logger,
            IProcessorCreator<Parcel, ProcessorResult> processorCreator,
            IApprovalProvider approvalProvider
            )
        {
            _logger = logger;
            _processorCreator = processorCreator;
            _approvalProvider = approvalProvider;
        }

        public void Process(Container container)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));

            try
            {
                var handler = _processorCreator.Create();

                foreach (Parcel parcel in container.Parcels)
                {
                    Parcel inner = parcel;
                    ProcessParcel(handler, inner);
                }
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, e.Message);
            }
        }

        private void ProcessParcel(IHandler<Parcel, ProcessorResult> handler, Parcel parcel)
        {
            Attempt<ProcessorResult> attempt;
            ParcelState parcelState;
            ProcessorResult result;
            
            do
            {

                attempt = handler.Handle(parcel);
                (parcelState, result) = attempt.GetParcelState();

                if (parcelState == ParcelState.NeedsApproval)
                {
                    bool approved = _approvalProvider.RequestApproval(parcel);
                    parcel = new Parcel(parcel, approved);
                }

            } while (parcelState == ParcelState.NeedsApproval);

            if (parcelState == ParcelState.NotSent)
            {
                _logger.LogWarning(attempt.Exception, "Unable to process parcel.");
                return;
            }
         
            _logger.LogInformation("Parcel sent via {HandlerName}. From {Sender} to {Receipient} [Weight: {Weight}; Value: {Value};]", result.HandlerName, result.Parcel.Sender, result.Parcel.Receipient, result.Parcel.Weight, result.Parcel.Value);
        }
    }
}