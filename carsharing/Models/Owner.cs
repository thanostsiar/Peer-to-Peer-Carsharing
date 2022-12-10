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

        public string OwnerId { get; set; } = null!;

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
