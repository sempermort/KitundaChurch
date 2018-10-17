using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KitundaChurch.Models
{
    public class Matumizi
    {
        public int MatumiziId { get; set; }
        [Display(Name="Jina la Mpokeaji")]
        public string Receiver { get; set; }
        [Display(Name = "Imetumikaje")]
        public string Usedfor { get; set; }
        public int Amount { get; set; }
        public int FormNo { get; set; }
        public virtual Department department { get; set; }
        public int DepartmentId { get; set; }
    }
}
