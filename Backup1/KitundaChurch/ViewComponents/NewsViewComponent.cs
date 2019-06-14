using KitundaChurch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitundaChurch.ViewComponents
{

    public class NewsViewComponent : ViewComponent
    {
        private readonly KitundaChurchContext _context;

        public NewsViewComponent(KitundaChurchContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int catId)
        {
            var list = new List<News>();
            if (catId == 0)
            {
                list = await _context.News.Where(n => n.CategoryId ==1).ToListAsync();
                return View(list);
            }
            else
            {
                list = await _context.News.Where(n => n.CategoryId == catId).ToListAsync();

                return View(list);
            }
        }
       
    }
}
