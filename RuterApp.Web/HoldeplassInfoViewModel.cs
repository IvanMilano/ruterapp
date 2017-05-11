using System;
using RuterApp.Models;

namespace RuterApp.Web
{
    public class HoldeplassInfoViewModel
    {
        public string Navn { get; set; }

        public string LinjeNavn { get; set; }

        public Direction Direction { get; set; }

        public TimeSpan TidTilAnkomst { get; set; }

        public TimeSpan Forsinkelse { get; set; }

        public bool Holdeplass { get; set; }
    }
}