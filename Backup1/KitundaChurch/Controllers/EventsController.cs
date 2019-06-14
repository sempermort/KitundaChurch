using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KitundaChurch.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using MoreLinq;

namespace KitundaChurch.Controllers
{
    public class EventsController : Controller
    {
        private readonly KitundaChurchContext _context;

        public EventsController(KitundaChurchContext context)
        {
            _context = context;
        }

        // GET: Events
        public ActionResult Index()
        {
            var list = _context.Events.Include(m=>m.Image).Where(n => n.timer >= DateTime.Now).ToList();
            var item = list.MinBy(b=>b.timer).SingleOrDefault();
            ViewBag.tot = item.timer;
            ViewBag.litle = item.Title;
            ViewBag.desc = item.contentual;
            ViewBag.image = "data:image/jpg;base64," + Convert.ToBase64String(item.Image.content, 0, item.Image.content.Length);
            ViewBag.mahal = item.place;
            return PartialView(list);
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Event @event = _context.Events.Find(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }
        //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult ViewSavedImage( )
        {
            //UserImageFile file = new UserImageFile();
            return PartialView("ViewSavedImage"/* file*/);
        }
        // GET: Events/Create
        [HttpGet]
        public ActionResult CreateAsync()
        {
           
            //Get the full file path which we will use to save the file.

            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync( Event @event, List<IFormFile> Upload)  
        {
            if (ModelState.IsValid)
            {
              

                    _context.Add(@event);
                    await _context.SaveChangesAsync();
                await RegimAsync(@event, Upload);
                return RedirectToAction("Index");

            }

               
            
                return View(@event);
        }
        public async Task RegimAsync(Event eve, List<IFormFile> Upload)
        {
            
            foreach (var a in Upload)
            {
                UserImageFile fil = new UserImageFile();
                fil.FileName = a.FileName;
                fil.ContentType = a.ContentType;
                using (var memorystream = new MemoryStream())
                {
                    a.CopyTo(memorystream);
                    fil.content = memorystream.ToArray();

                }
                fil.EventId=eve.Id;
                     _context.Add(fil);
                await _context.SaveChangesAsync();
            }
        }
        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return  NotFound();
            }
            Event @event = _context.Events.Find(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,image,timer,contentual")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(@event).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return  NotFound();
            }
            Event @event = _context.Events.Find(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = _context.Events.Find(id);
            _context.Events.Remove(@event);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
