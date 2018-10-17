using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KitundaChurch.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace KitundaChurch.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly KitundaChurchContext _context;

        public AlbumsController(KitundaChurchContext context)
        {
            _context = context;
        }

        // GET: Albums
        public  IActionResult Index()
        {
            var list =  _context.Album.ToList();
   
            ViewBag.song = _context.Songs.ToList();
            return View(list);
        }
      
        
            // GET: Albums/Details/5
            public async Task<IActionResult> DetailsAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Album
                .SingleOrDefaultAsync(m => m.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }
        public IActionResult Resong(int? id)
        {


            return ViewComponent("SongList", new { AlbumId = id });
        }

        // GET: Albums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> CreateAsync([Bind("AlbumId,Title,Year,Author")] Album album, List<IFormFile> upload)
        {
            //try
            //{
                if (ModelState.IsValid)
                {
                _context.Add(album);
               await _context.SaveChangesAsync();
                await RegimeAsync(album,upload);
                return RedirectToAction(nameof(Index));
                }
            //}
            //catch (DBConcurrencyException  ex )
            //{
            //    //Log the error (uncomment ex variable name and write a log.
            //    ModelState.AddModelError("" /*"Unable to save changes. " +
            //    //    "Try again, and if the problem persists " +
            //    //    "see your system administrator."*/);
            //}
        
            return View(album);
        }

        public async Task RegimeAsync(Album album, List<IFormFile> upload)
        {
            foreach (var a in upload)
            {
                Song song = new Song();
                song.songName = a.FileName;
                song.ContentType = a.ContentType;
                using (var memorystream = new MemoryStream())
                {
                    a.CopyTo(memorystream);
                    song.songData = memorystream.ToArray();

                }
                song.AlbumId = album.AlbumId;
                _context.Add(song);
               await _context.SaveChangesAsync();
            }
        }

        // GET: Albums/Edit/5
        public async Task<IActionResult> EditAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Album.SingleOrDefaultAsync(m => m.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int id, [Bind("AlbumId,songId,Title,Year,Author")] Album album)
        {
            if (id != album.AlbumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(album);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.AlbumId))
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
            return View(album);
        }

        // GET: Albums/Delete/5
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Album
                .SingleOrDefaultAsync(m => m.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedAsync(int id)
        {
            var album = await _context.Album.SingleOrDefaultAsync(m => m.AlbumId == id);
            _context.Album.Remove(album);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(int id)
        {
            return _context.Album.Any(e => e.AlbumId == id);
        }
    }
   
}
