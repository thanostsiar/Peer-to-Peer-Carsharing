namespace carsharing.Models
{
    public class CreatePost
    {

        public string Title { get; set; }
        public string Body { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public int MaxDaysOfRent { get; set; }
        public string Images { get; set; }
    }
}
