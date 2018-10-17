using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KitundaChurch.Models
{
    public class ChurchMembers
    {
        public int ChurchMembersId { get; set; }
        [Key]
        public string Name { get; set; }
        [Display(Name ="Jina la Familia")]
        public string FamilyName { get; set; }
        public string Zone { get; set; }
        [Display(Name ="Marital Status")]
        public string MaritalStatus { get; set; }
       
        public string Resident { get; set; }
        [Display(Name = "Darasa Shule ya Sabato")]
        public string DarasaSS { get; set; }
        [Display(Name="Namba ya Ushirika")]
        public int MemberShipNo { get; set; }
        
        [Display(Name="phone Number")]
        public int PhoneNo { get; set; }
        public string Status { get; set; }
        public int MatoleoId { get; set; }
        public ICollection<Matoleo> matoleo { get; set; }

    }
}
