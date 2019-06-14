using KitundaChurch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitundaChurch.ViewComponents
{

    public class SongListViewComponent : ViewComponent
    {
        private readonly KitundaChurchContext _context;

        public SongListViewComponent(KitundaChurchContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? AlbumId)
        {

            var album = await ListingAsync(AlbumId);



            return View(album);
        }
        public async Task<List<Song>> ListingAsync(int? AlbumId)
        {
            return await _context.Songs.Where(x => x.AlbumId == AlbumId).ToListAsync();
        }
    }
}
