using System;
using System.Collections.Generic;

namespace carsharing.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Posts = new HashSet<Post>();
        }

        public int VehicleId { get; set; }
        public int OwnerId { get; set; }
        public string Manufacturer { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }

        public virtual Owner Owner { get; set; } = null!;
        public virtual RentedVehicle RentedVehicle { get; set; } = null!;
        public virtual ICollection<Post> Posts { get; set; }
    }
}
