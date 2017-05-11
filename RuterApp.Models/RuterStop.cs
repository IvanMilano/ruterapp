namespace RuterApp.Models
{
    public class RuterStop
    {
        public string District { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string PlaceType { get; set; }

        public bool IsHub { get; set; }
        public string[] Lines { get; set; }
        public string ShortName { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
