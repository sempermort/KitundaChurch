using KitundaChurch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitundaChurch.ViewComponents
{

    public class PlayListViewComponent : ViewComponent
    {
        private readonly KitundaChurchContext _context;

        public PlayListViewComponent(KitundaChurchContext context)
        {
            _context = context;
        }
        public async Task <IViewComponentResult> InvokeAsync()
        {

           

            var album = await _context.Album.ToListAsync();

            ViewBag.song = await _context.Songs.ToListAsync();
           

            return View("play",album);
        }
        //public async Task<List<Song>> Listing(int? AlbumId)
        //{
        //    return await _context.Songs.Where(x => x.AlbumId == AlbumId).ToListAsync();
        //}
    }
}
