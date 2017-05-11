namespace RuterApp.Models
{
    public class RuterStopsByLine
    {
        public string[] Lines { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public string Zone { get; set; }

        public string ShortName { get; set; }

        public bool IsHub { get; set; }

        public int ID { get; set; }

        public string Name { get; set; }

        public string District { get; set; }

        public string PlaceType { get; set; }
    }
}