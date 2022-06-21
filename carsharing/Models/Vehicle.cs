using System;
using System.Collections.Generic;

namespace carsharing.Models
{
    public partial class Vehicle
    {
        public int VehicleId { get; set; }
        public int OwnerId { get; set; }
        public string Manufacturer { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Color { get; set; } = null!;
        public int Year { get; set; }

        public virtual Owner Owner { get; set; } = null!;
        public virtual Post Post { get; set; } = null!;
        public virtual RentedVehicle RentedVehicle { get; set; } = null!;
    }
}
