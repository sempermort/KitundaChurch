using KitundaChurch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitundaChurch.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {

        private readonly KitundaChurchContext _context;

        public CategoryViewComponent(KitundaChurchContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? GalleryId)
        {
            var album =await  _context.Gallery.Include(n=>n.image).ToListAsync();
            if(GalleryId!=null)
            {
                album = await ListingAsync(GalleryId);
            }
            



            return View(album);
        }
        public async Task<List<Gallery>> ListingAsync(int? GalleryId)
        {
            return await _context.Gallery.Include(m=>m.image).Where(x =>x.GalleryId == GalleryId).ToListAsync();
        }
    }

}