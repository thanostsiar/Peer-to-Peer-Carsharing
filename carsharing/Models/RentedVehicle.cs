using System;
using System.Collections.Generic;

namespace carsharing.Models
{
    public partial class RentedVehicle
    {
        public int VehicleId { get; set; }
        public string RenterId { get; set; } = null!;
        public DateOnly DayRented { get; set; }
        public DateOnly DayOfReturn { get; set; }
        public TimeOnly TimeRented { get; set; }
        public TimeOnly TimeOfReturn { get; set; }

        public virtual Renter Renter { get; set; } = null!;
        public virtual Vehicle Vehicle { get; set; } = null!;
    }
}
