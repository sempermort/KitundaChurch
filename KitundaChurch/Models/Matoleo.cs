using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KitundaChurch.Models
{
    public class Matoleo
    {
        public int MatoleoId { get; set; }
        [Display(Name = "Jumla")]
        [Required]
        public int Total { get; set; } = 0;
        [Display(Name = "Tarehe")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Savetime { get; set; } =DateTime.Now;

        public double Zaka { get; set; } = 0;
        [Display(Name = "Conf")]
        public double sadakaConf { get; set; } = 0;
        [Display(Name = "Bk ")]
        public double sadakaBk { get; set; } = 0;
        [Display(Name = "Majengo ")]
        public double sadakaMajengo { get; set; } = 0;
        [Display(Name = "Makambi")]
        public double sadakaMakambi { get; set; } = 0;

        [Display(Name = "Mpango")]
        public double MpangoKanisa { get; set; } = 0;
        public virtual ChurchMembers ChurchMembers { get; set; }
        public virtual  int ChurchMembersId { get; set; }
        public  ICollection<Mengineyo> mengineyo { get; set; }

    }

   
}
