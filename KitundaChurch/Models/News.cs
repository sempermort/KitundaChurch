using System;
using System.Collections.Generic;

namespace KitundaChurch.Models
{
    public class News
    {
        public int Id { get; set; }
       
        public string content { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public IList<Category> category { get; set; }
        public byte images { get; set; }
        public DateTime? time { get; set; }
        

    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string CName { get; set; }
    }
}