using System.ComponentModel.DataAnnotations;

namespace KitundaChurch.Models
{
    public class UserImageFile
    {
        public virtual int UserImageFileId { get; set; }
        [StringLength(255)]
        public virtual string FileName { get; set; }
        [StringLength(100)]
        public virtual string ContentType { get; set; }
        public virtual byte[] content { get; set; }
        public virtual Event Event { get; set; }
        public virtual int EventId { get; set; }
    }
}