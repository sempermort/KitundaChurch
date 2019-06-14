using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KitundaChurch.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Display(Name="Name of Department")]
        public string Name { get; set; }
        public int Total { get; set; }
        public virtual ICollection<Matumizi> matumizi { get; set; }
    }
}