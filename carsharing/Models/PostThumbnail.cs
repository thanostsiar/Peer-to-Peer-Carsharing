using System;
using System.Collections.Generic;

namespace carsharing.Models
{
    public partial class PostThumbnail
    {
        public int PostId { get; set; }
        public string ThumbnailUrl { get; set; } = null!;

        public virtual Post Post { get; set; } = null!;
    }
}
