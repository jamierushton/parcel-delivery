using System;
using Microsoft.Extensions.Logging;
using ParcelDelivery.ConsoleApp.Abstractions;

namespace ParcelDelivery.ConsoleApp
{
    public sealed class ConsoleApprovalProvider : IApprovalProvider
    {
        private readonly ILogger<ConsoleApprovalProvider> _logger;
        private readonly IConsole _console;

        public ConsoleApprovalProvider(ILogger<ConsoleApprovalProvider> logger, IConsole console)
        {
            _logger = logger;
            _console = console;
        }

        public bool RequestApproval(Parcel parcel)
        {
            _console.WriteLine("---------------------------");

            _logger.LogWarning("Parcel requires approval before it can be sent...");
            _logger.LogWarning("{Sender} from {Receipient} [Weight: {Weight}; Value: {Value};]", parcel.Sender, parcel.Receipient, parcel.Weight, parcel.Value);

            ConsoleKey response;
            do
            {
                _console.WriteLine("Would you like to authorise this parcel? (y/N)");
                response = _console.ReadKey(false).Key;

                if (response == ConsoleKey.Enter)
                    response = ConsoleKey.N;

            } while (response != ConsoleKey.Y && response != ConsoleKey.N);

            _console.WriteLine("---------------------------");

            return response == ConsoleKey.Y;
        }
    }
}