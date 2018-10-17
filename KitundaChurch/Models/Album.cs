using System.Collections.Generic;

namespace KitundaChurch.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
      

        public string Title { get; set; }
        public int Year { get; set; }

        public string Author { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}