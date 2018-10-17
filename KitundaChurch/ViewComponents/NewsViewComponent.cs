using KitundaChurch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            // if(category.CategoryId==0)
            //{
            //    category.CategoryId = 1;
            //}
            //else
            //{
            //    category.CategoryId = category.CategoryId;
            //}

            var list =  _context.News.Where(n=>n.CategoryId==catId);

            return View ( await list.ToListAsync());

        }
       
    }
}
