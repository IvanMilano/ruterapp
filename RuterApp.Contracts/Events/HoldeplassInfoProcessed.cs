using System;
using NServiceBus;
using RuterApp.Klient;

namespace RuterApp.Contracts.Events
{
    public class HoldeplassInfoProcessed : IEvent
    {
        public string Navn { get; set; }

        public string LinjeNavn { get; set; }

        public Direction Direction { get; set; }

        public bool Holdeplass { get; set; }

        public TimeSpan TidTilAnkomst { get; set; }

        public TimeSpan Forsinkelse { get; set; }
    }
}