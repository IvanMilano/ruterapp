using Newtonsoft.Json;
using NServiceBus;
using RuterApp.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RuterApp.Contracts.Commands;
using RuterApp.Models;
using JsonSerializer = NServiceBus.JsonSerializer;

namespace RuterApp.Klient
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncMain().GetAwaiter().GetResult();
        }

        static async Task AsyncMain()
        {
            Console.Title = "Client";
            Console.WriteLine("Client...");

            var endpointConfiguration = new EndpointConfiguration(
                endpointName: "RuterApp.Client");

            endpointConfiguration.SendFailedMessagesTo("error");
            endpointConfiguration.UseSerialization<JsonSerializer>();
            endpointConfiguration.EnableInstallers();
            endpointConfiguration.UsePersistence<InMemoryPersistence>();

            var endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);
            try
            {
                await SendHoldeplassInfo(endpointInstance);
            }
            finally
            {
                await endpointInstance.Stop().ConfigureAwait(false);
            }
        }

        static async Task SendHoldeplassInfo(IEndpointInstance endpointInstance)
        {
            Console.WriteLine("Press enter to send a message");
            Console.WriteLine("press any key to exit");

            while (true)
            {
                var key = Console.ReadKey();
                Console.WriteLine();

                if (key.Key != ConsoleKey.Enter)
                {
                    return;
                }

                var urlGetStopVisit = "http://reisapi.ruter.no/StopVisit/GetDepartures/3010011?json=true"; //jernbanetorget

                var departures = _download_serialized_json_data<List<Departure>>(urlGetStopVisit);

                foreach (var departure in departures)
                {
                    var direction = departure.MonitoredVehicleJourney.DirectionRef == "1" ? Direction.East : Direction.West;

                    var processHoldeplassInfo = ToProcessHoldeplassInfo(departure, direction);
                    await endpointInstance.Send("RuterApp.Server", processHoldeplassInfo);
                }

                urlGetStopVisit = "http://reisapi.ruter.no/StopVisit/GetDepartures/3010020?json=true"; //Stortinget
                departures = _download_serialized_json_data<List<Departure>>(urlGetStopVisit);

                foreach (var departure in departures)
                {
                    var processHoldePlassInfo = ToProcessHoldeplassInfo(departure, Direction.Unknown);
                    await endpointInstance.Send("RuterApp.Server", processHoldePlassInfo);
                }
            }
        }

        private static ProcessHoldeplassInfo ToProcessHoldeplassInfo(Departure departure, Direction direction)
        {
            return new ProcessHoldeplassInfo
            {
                HoldeplassNavn = "Jernbanetorget",
                Linjenavn = departure.MonitoredVehicleJourney.DestinationName,
                HoldeplassId = departure.MonitoringRef,
                Linjenr = departure.MonitoredVehicleJourney.LineRef,
                TidTilAnkomst = departure.MonitoredVehicleJourney.MonitoredCall.ExpectedArrivalTime - DateTime.Now,
                Forsinkelse =
                    departure.MonitoredVehicleJourney.MonitoredCall.ExpectedArrivalTime -
                    departure.MonitoredVehicleJourney.MonitoredCall.AimedArrivalTime,
                Holdeplass = departure.MonitoredVehicleJourney.MonitoredCall.VehicleAtStop,
                Id = departure.MonitoredVehicleJourney.VehicleRef,
                Direction = direction
            };
        }

        private static T _download_serialized_json_data<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                try
                {
                    w.Encoding = Encoding.UTF8;
                    json_data = w.DownloadString(url);
                }
                catch (Exception)
                {
                    Debug.WriteLine("Error UTF8 encoding");
                }

                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }
    }
}
