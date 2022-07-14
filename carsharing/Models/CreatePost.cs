using System.ComponentModel.DataAnnotations;

namespace carsharing.Models
{
    public class CreatePost
    {
        [Required(ErrorMessage = "Please enter the title of the post!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter the city where your car can be rented!")]
        public string City { get; set; }
        public DateOnly Created { get; set; }
        [Required(ErrorMessage = "Please enter the cost of each renting day!")]
        public decimal CostPerDay { get; set; }
        [Required(ErrorMessage = "Please enter any extra information that needs to be mantioned about the car!")]
        public string Body { get; set; }
        [Required(ErrorMessage = "Please insert the thumbnail image of your post!")]
        public string ThumbnailUrl { get; set; }
        [Required(ErrorMessage = "Please enter the manufacturer of the car!")]
        public string Manufacturer { get; set; }
        [Required(ErrorMessage = "Please enter the model of the car!")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Please enter the type of the car!")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Please enter the color of the car!")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Please enter the year of the car!")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Please enter the maximum number of renting days of the car!")]
        public int MaxDaysOfRent { get; set; }
        /*public string Images { get; set; }*/
    }
}
