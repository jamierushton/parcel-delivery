using Microsoft.Extensions.DependencyInjection;
using ParcelDelivery.Abstractions;
using ParcelDelivery.ConsoleApp.Abstractions;
using Serilog;

namespace ParcelDelivery.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Program.ConfigureLogger();

                var serviceProvider = ConfigureServices().BuildServiceProvider();

                serviceProvider.GetRequiredService<ParcelApplication>()
                               .ProcessFromFile(@"C:\ParcelDelivery\Data\Container_68465468.xml");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<ParcelApplication>();

            services.AddSingleton<IFileSystem, LocalFileSystem>();
            services.AddSingleton<IConsole, ConsoleImpl>();

            services.AddSingleton<IParcelProcessor, ParcelProcessor>();
            services.AddSingleton<IDeserialiser, XmlDeserialiser>();
            
            services.AddSingleton<IApprovalProvider, ConsoleApprovalProvider>();
            services.AddSingleton<IProcessorCreator<Parcel, ProcessorResult>, DefaultWorkflow>();

            services
                .AddLogging(x => { x.AddSerilog(); });

            return services;
        }

        private static void ConfigureLogger() =>
            Log.Logger = new LoggerConfiguration()
#if DEBUG
                         .MinimumLevel.Debug()
#else
                         .MinimumLevel.Information()
#endif
                         .WriteTo.Console()
                         .CreateLogger();
    }
}
