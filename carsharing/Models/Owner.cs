using System;
using System.Collections.Generic;

namespace carsharing.Models
{
    public partial class Owner
    {
        public Owner()
        {
            Posts = new HashSet<Post>();
            Vehicles = new HashSet<Vehicle>();
        }

        public int OwnerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int Age { get; set; }
        public string ProfilePicture { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
