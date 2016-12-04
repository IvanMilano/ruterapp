using System;

namespace RuterApp.Models
{
    public class Departure
    {

            public DateTime RecordedAtTime { get; set; }
            public string MonitoringRef { get; set; }
            public Monitoredvehiclejourney MonitoredVehicleJourney { get; set; }
            public Extensionsa Extensions { get; set; }

        public class Monitoredvehiclejourney
        {
            public string LineRef { get; set; }
            public string DirectionRef { get; set; }
            public Framedvehiclejourneyref FramedVehicleJourneyRef { get; set; }
            public string PublishedLineName { get; set; }
            public string DirectionName { get; set; }
            public string OperatorRef { get; set; }
            public string OriginName { get; set; }
            public string OriginRef { get; set; }
            public string DestinationRef { get; set; }
            public string DestinationName { get; set; }
            public DateTime OriginAimedDepartureTime { get; set; }
            public DateTime DestinationAimedArrivalTime { get; set; }
            public bool Monitored { get; set; }
            public bool InCongestion { get; set; }
            public string Delay { get; set; }
            public Trainblockpart TrainBlockPart { get; set; }
            public string BlockRef { get; set; }
            public string VehicleRef { get; set; }
            public int VehicleMode { get; set; }
            public string VehicleJourneyName { get; set; }
            public Monitoredcall MonitoredCall { get; set; }
            public string VehicleFeatureRef { get; set; }
        }

        public class Framedvehiclejourneyref
        {
            public string DataFrameRef { get; set; }
            public string DatedVehicleJourneyRef { get; set; }
        }

        public class Trainblockpart
        {
            public int NumberOfBlockParts { get; set; }
        }

        public class Monitoredcall
        {
            public int VisitNumber { get; set; }
            public bool VehicleAtStop { get; set; }
            public string DestinationDisplay { get; set; }
            public DateTime AimedArrivalTime { get; set; }
            public DateTime ExpectedArrivalTime { get; set; }
            public DateTime AimedDepartureTime { get; set; }
            public DateTime ExpectedDepartureTime { get; set; }
            public string DeparturePlatformName { get; set; }
        }

        public class Extensionsa
        {
            public bool IsHub { get; set; }
            public object OccupancyData { get; set; }
            public object[] Deviations { get; set; }
            public string LineColour { get; set; }
        }

    }
}
