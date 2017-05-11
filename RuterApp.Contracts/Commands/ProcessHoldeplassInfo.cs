using System;
using NServiceBus;
using RuterApp.Models;

namespace RuterApp.Contracts.Commands
{
    public class ProcessHoldeplassInfo : ICommand
    {
        public string HoldeplassId { get; set; }

        public string HoldeplassNavn { get; set; }

        public string Linjenavn { get; set; }

        public string Linjenr { get; set; }

        public TimeSpan TidTilAnkomst { get; set; }

        public int AvstandFraForrige { get; set; }

        public TimeSpan Forsinkelse { get; set; }

        public bool Holdeplass { get; set; }

        public string Id { get; set; }

        public Direction Direction { get; set; }
    }
}