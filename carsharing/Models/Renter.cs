using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace carsharing.Models
{
    public partial class Renter
    {
        public Renter()
        {
            PostComments = new HashSet<PostComment>();
            RentedVehicles = new HashSet<RentedVehicle>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RenterId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int Age { get; set; }
        public double Experience { get; set; }
        public string ProfilePicture { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<PostComment> PostComments { get; set; }
        public virtual ICollection<RentedVehicle> RentedVehicles { get; set; }
    }
}
