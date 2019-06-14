namespace KitundaChurch.Models
{
    public class Song
    {
        public int songId { get; set; }
        
        public string songName { get; set; }
        public byte[] songData { get; set; }
        public string ContentType { get; set; }
     
        public Album Album { get; set; }
        public int AlbumId { get; set; }
    }
}
