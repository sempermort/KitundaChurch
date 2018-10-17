using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KitundaChurch.Models
{
    public class Event
    {
        public Event()
        {
         
            timer = DateTime.Now;
        }
        public int Id { get; set; }
     
        [Display(Name ="DateTime")]
        public DateTime timer { get; set; }

        [Display(Name = "Title")]
        [DisplayFormat(DataFormatString = "{0:hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        public string Title { get; set; }
        [Display(Name = " more explanation")]
        [DataType(DataType.MultilineText)]
        public string contentual { get; set; }
        public string place { get; set; }
        public virtual/* ICollection< */UserImageFile Image { get; internal set; }
        //public virtual UserImageFile image { get; set; }
    }
}