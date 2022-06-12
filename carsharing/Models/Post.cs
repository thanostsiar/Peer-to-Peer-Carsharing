using System;
using System.Collections.Generic;

namespace carsharing.Models
{
    public partial class Post
    {
        public int PostId { get; set; }
        public int OwnerId { get; set; }
        public int VehicleId { get; set; }
        public string Title { get; set; } = null!;
        public string Body { get; set; } = null!;
        public double Rating { get; set; }
        public DateOnly Created { get; set; }

        public virtual Owner Owner { get; set; } = null!;
        public virtual Vehicle Vehicle { get; set; } = null!;
    }
}
