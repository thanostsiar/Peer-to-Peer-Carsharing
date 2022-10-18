using System;
using System.Collections.Generic;

namespace carsharing.Models
{
    public partial class Post
    {
        public Post()
        {
            PostComments = new HashSet<PostComment>();
            PostImages = new HashSet<PostImage>();
        }

        public int PostId { get; set; }
        public string OwnerId { get; set; } = null!;
        public int VehicleId { get; set; }
        public string Title { get; set; } = null!;
        public string Body { get; set; } = null!;
        public string City { get; set; } = null!;
        public double Rating { get; set; }
        public string ThumbnailUrl { get; set; } = null!;
        public DateOnly Created { get; set; }
        public decimal CostPerDay { get; set; }
        public int MaxDaysOfRent { get; set; }

        public virtual Owner Owner { get; set; } = null!;
        public virtual Vehicle Vehicle { get; set; } = null!;
        public virtual ICollection<PostComment> PostComments { get; set; }
        public virtual ICollection<PostImage> PostImages { get; set; }
    }
}
