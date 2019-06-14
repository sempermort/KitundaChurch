using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitundaChurch.Models
{
    public class Gallery
    {
        public int GalleryId { get; set;  }
        public string Category { get;  set;  }
        public virtual ICollection<UserImageFile> image { get; set; }

    }
}
