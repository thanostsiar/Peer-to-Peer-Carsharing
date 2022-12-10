using System;
using System.Collections.Generic;

namespace carsharing.Models
{
    public partial class Renter
    {
        public Renter()
        {
            PostComments = new HashSet<PostComment>();
            RentedVehicles = new HashSet<RentedVehicle>();
        }

        public string RenterId { get; set; } = null!;

        public virtual ICollection<PostComment> PostComments { get; set; }
        public virtual ICollection<RentedVehicle> RentedVehicles { get; set; }
    }
}
