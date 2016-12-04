using NServiceBus;
using NServiceBus.Logging;
using RuterApp.Contracts;
using System;
using System.Threading.Tasks;
using RuterApp.Contracts.Commands;
using RuterApp.Contracts.Events;

namespace RuterApp.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncMain().GetAwaiter().GetResult();
        }

        static async Task AsyncMain()
        {
            Console.Title = "RuterApp.Server";
            var endpointConfiguration = new EndpointConfiguration("RuterApp.Server");
            endpointConfiguration.UseSerialization<JsonSerializer>();
            endpointConfiguration.EnableInstallers();
            endpointConfiguration.UsePersistence<InMemoryPersistence>();
            endpointConfiguration.SendFailedMessagesTo("error");

            var endpointInstance = await Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);
            try
            {
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
            finally
            {
                await endpointInstance.Stop()
                    .ConfigureAwait(false);
            }
        }

        public class HoldeplassHandler : IHandleMessages<ProcessHoldeplassInfo>
        {
            static ILog log = LogManager.GetLogger<HoldeplassHandler>();

            public Task Handle(ProcessHoldeplassInfo message, IMessageHandlerContext context)
            {
                log.Info($"Holdeplass:{message.HoldeplassNavn}," +
                         $" med id: {message.HoldeplassId}, " +
                         $"Id: {message.Id}, " +
                         $"på holdeplassen: {message.Holdeplass}, " +
                         $"linje: {message.Linjenr}, " +
                         $"Ankomst:{message.TidTilAnkomst}, " +
                         $"Linjenavn:{message.Linjenavn}, " +
                         $"Forsinkelse:{message.Forsinkelse}, " +
                         $"Retning:{message.Direction}");

                var holdeplassProcessedEvent = new HoldeplassInfoProcessed
                {
                    Navn = message.HoldeplassNavn,
                    LinjeNavn = message.Linjenavn,
                    Direction = message.Direction,
                    Holdeplass = message.Holdeplass,
                    TidTilAnkomst = message.TidTilAnkomst,
                    Forsinkelse = message.Forsinkelse
                };

                return context.Publish(holdeplassProcessedEvent);
            }
        }
    }
}
