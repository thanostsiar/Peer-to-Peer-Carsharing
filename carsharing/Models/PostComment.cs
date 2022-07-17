using System;
using System.Collections.Generic;

namespace carsharing.Models
{
    public partial class PostComment
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int RenterId { get; set; }
        public int VehicleId { get; set; }
        public DateOnly Created { get; set; }
        public double Rating { get; set; }
        public string Body { get; set; } = null!;

        public virtual Post Post { get; set; } = null!;
        public virtual Renter Renter { get; set; } = null!;
    }
}
