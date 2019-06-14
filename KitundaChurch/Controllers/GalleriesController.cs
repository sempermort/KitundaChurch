using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KitundaChurch.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace KitundaChurch.Controllers
{
    public class GalleriesController : Controller
    {
        private readonly KitundaChurchContext _context;

        public GalleriesController(KitundaChurchContext context)
        {
            _context = context;
        }

        // GET: Galleries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gallery.ToListAsync());
        }

        // GET: Galleries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _context.Gallery
                .SingleOrDefaultAsync(m => m.GalleryId == id);
            if (gallery == null)
            {
                return NotFound();
            }

            return View(gallery);
        }

        // GET: Galleries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Galleries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GalleryId,Category")] Gallery gallery, List<IFormFile> upload)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gallery);
                await _context.SaveChangesAsync();
                await RegimeAsync(gallery, upload);
                return RedirectToAction(nameof(Index));
            }
            return View(gallery);
        }

        public async Task RegimeAsync(Gallery gallery, List<IFormFile> upload)
        {
            foreach (var a in upload)
            {
                UserImageFile image = new UserImageFile();
                image.FileName = a.FileName;
                image.ContentType = a.ContentType;
                using (var memorystream = new MemoryStream())
                {
                    a.CopyTo(memorystream);
                    image.content = memorystream.ToArray();

                }
                image.GalleryId = gallery.GalleryId;
                _context.Add(image);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IActionResult> IntermediateAsync(int? GalleryId)
        {
         var  album = new List<UserImageFile>();
            if (GalleryId == 0)
            {
                 album = await _context.UserImageFile.Where(n=>n.GalleryId!=null).ToListAsync();
                return new JsonResult(album);
            }
            else if (GalleryId != null)
            {
                album = await ListingAsync(GalleryId);
                return new JsonResult(album);
            }

           


            return new JsonResult(album);
        }
        public async Task<List<UserImageFile>> ListingAsync(int? GalleryId)
            {
                return await _context.UserImageFile.Where(x => x.GalleryId == GalleryId).ToListAsync();
            }

      
            // GET: Galleries/Edit/5
            public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _context.Gallery.SingleOrDefaultAsync(m => m.GalleryId == id);
            if (gallery == null)
            {
                return NotFound();
            }
            return View(gallery);
        }

        // POST: Galleries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GalleryId,Category,UserImageFileId")] Gallery gallery)
        {
            if (id != gallery.GalleryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gallery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GalleryExists(gallery.GalleryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(gallery);
        }

        // GET: Galleries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _context.Gallery
                .SingleOrDefaultAsync(m => m.GalleryId == id);
            if (gallery == null)
            {
                return NotFound();
            }

            return View(gallery);
        }

        // POST: Galleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gallery = await _context.Gallery.SingleOrDefaultAsync(m => m.GalleryId == id);
            _context.Gallery.Remove(gallery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GalleryExists(int id)
        {
            return _context.Gallery.Any(e => e.GalleryId == id);
        }

   
    }
}
