using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace carsharing.Models
{
    public class FilterPost
    {
        // Filter fields
        public string CarColor { get; set; }

        public List<SelectListItem> SelectCarColor { get; private set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "", Text = "-"},
            new SelectListItem { Value = "Beige", Text = "Beige"},
            new SelectListItem { Value = "Black", Text = "Black"},
            new SelectListItem { Value = "Blue", Text = "Blue"},
            new SelectListItem { Value = "Brown", Text = "Brown"},
            new SelectListItem { Value = "Green", Text = "Green"},
            new SelectListItem { Value = "Navy", Text = "Navy"},
            new SelectListItem { Value = "Orange", Text = "Orange"},
            new SelectListItem { Value = "Red", Text = "Red"},
            new SelectListItem { Value = "Silver", Text = "Silver"},
            new SelectListItem { Value = "White", Text = "White"},
        };

        // used for filtering based on Newer or Oldest post
        public string CreatedAt { get; set; }

        public List<SelectListItem> SelectCreatedAt { get; private set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "", Text = "-" },
            new SelectListItem { Value = "Newest", Text = "Newest posts" },
            new SelectListItem { Value = "Oldest", Text = "Oldest posts" },

        };

        public string CarManufacturer { get; set; }

        public List<SelectListItem> SelectCarManufacturer { get; private set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "", Text = "-" },
            new SelectListItem { Value = "Alfa Romeo", Text = "Alfa Romeo" },
            new SelectListItem { Value = "Arash", Text = "Arash" },
            new SelectListItem { Value = "Aston Martin", Text = "Aston Martin" },
            new SelectListItem { Value = "Audi", Text = "Audi" },
            new SelectListItem { Value = "Bentley", Text = "Bentley" },
            new SelectListItem { Value = "BMW", Text = "BMW" },
            new SelectListItem { Value = "Bristol", Text = "Bristol" },
            new SelectListItem { Value = "Bugatti", Text = "Bugatti" },
            new SelectListItem { Value = "Cadillac", Text = "Cadillac" },
            new SelectListItem { Value = "Chevrolet", Text = "Chevrolet" },
            new SelectListItem { Value = "Citroen", Text = "Citroen" },
            new SelectListItem { Value = "Dacia", Text = "Dacia" },
            new SelectListItem { Value = "Daewoo", Text = "Daewoo" },
            new SelectListItem { Value = "DAF", Text = "DAF" },
            new SelectListItem { Value = "Daihatsu", Text = "Daihatsu" },
            new SelectListItem { Value = "Dodge", Text = "Dodge" },
            new SelectListItem { Value = "Ferrari", Text = "Ferrari" },
            new SelectListItem { Value = "Fiat", Text = "Fiat" },
            new SelectListItem { Value = "Ford", Text = "Ford" },
            new SelectListItem { Value = "Honda", Text = "Honda" },
            new SelectListItem { Value = "Hyundai", Text = "Hyundai" },
            new SelectListItem { Value = "Jaguar", Text = "Jaguar" },
            new SelectListItem { Value = "Jeep", Text = "Jeep" },
            new SelectListItem { Value = "Kia", Text = "Kia" },
            new SelectListItem { Value = "Lamborghini", Text = "Lamborghini" },
            new SelectListItem { Value = "Land_Rover", Text = "Land Rover" },
            new SelectListItem { Value = "Lexus", Text = "Lexus" },
            new SelectListItem { Value = "Mazda", Text = "Mazda" },
            new SelectListItem { Value = "McLaren", Text = "McLaren" },
            new SelectListItem { Value = "Mercedes", Text = "Mercedes" },
            new SelectListItem { Value = "Mitsubishi", Text = "Mitsubishi" },
            new SelectListItem { Value = "Nissan", Text = "Nissan" },
            new SelectListItem { Value = "Opel", Text = "Opel" },
            new SelectListItem { Value = "Peugeot", Text = "Peugeot" },
            new SelectListItem { Value = "Porsche", Text = "Porsche" },
            new SelectListItem { Value = "Renault", Text = "Renault" },
            new SelectListItem { Value = "Rolls Royce", Text = "Rolls Royce" },
            new SelectListItem { Value = "Seat", Text = "Seat" },
            new SelectListItem { Value = "Skoda", Text = "Skoda" },
            new SelectListItem { Value = "Smart", Text = "Smart" },
            new SelectListItem { Value = "Subaru", Text = "Subaru" },
            new SelectListItem { Value = "Suzuki", Text = "Suzuki" },
            new SelectListItem { Value = "Tesla", Text = "Tesla" },
            new SelectListItem { Value = "Toyota", Text = "Toyota" },
            new SelectListItem { Value = "Volkswagen", Text = "Volkswagen" },
            new SelectListItem { Value = "Volvo", Text = "Volvo" },
        };

        public string CarType { get; set; }

        public List<SelectListItem> SelectCarType { get; private set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "", Text = "-" },
            new SelectListItem { Value = "Small", Text = "Small" },
            new SelectListItem { Value = "Medium", Text = "Medium" },
            new SelectListItem { Value = "Large", Text = "Large" },
            new SelectListItem { Value = "Suv", Text = "Suv" },
            new SelectListItem { Value = "Van", Text = "Van" },
            new SelectListItem { Value = "Convertible", Text = "Convertible" },
            new SelectListItem { Value = "Luxury", Text = "Luxury" },
        };
    }
}
