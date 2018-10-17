using KitundaChurch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoreLinq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KitundaChurch.ViewComponents
{

    public class EventViewComponent : ViewComponent
    {
        private readonly KitundaChurchContext _context;

        public EventViewComponent(KitundaChurchContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {


            var list = _context.Events.Include(n=>n.Image).Where(n => n.timer >= DateTime.Now).ToList();
            var item = list.MinBy(b => b.timer).SingleOrDefault();
            ViewBag.tot = item.timer;
            ViewBag.litle = item.Title;
            ViewBag.desc = item.contentual;
            ViewBag.image = "data:image/png;base64," + Convert.ToBase64String(item.Image.content, 0, item.Image.content.Length);
            ViewBag.mahal = item.place;
           

            return View(list);
        }
        //public async Task<List<Song>> Listing(int? AlbumId)
        //{
        //    return await _context.Songs.Where(x => x.AlbumId == AlbumId).ToListAsync();
        //}
    }
}
