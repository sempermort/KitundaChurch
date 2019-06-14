using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KitundaChurch.Models;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KitundaChurchControllers
{
    public class NewsController : Controller
    {
      
            private readonly KitundaChurchContext _context;

            public NewsController(KitundaChurchContext context)
            {
                _context = context;
            }
            // GET: News
            public ActionResult Index()
        {  
           
            return View( _context.News.ToList());
        }

        // GET: News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            News news = _context.News.Find(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        // GET: News/Create
        [HttpGet]
        public ActionResult Create( )
        {
            ViewBag.Listed = new SelectList(_context.Category.Select(n=>n.CName).ToList());
           News news = new News();
            news.time = DateTime.Now;
            return View(news);
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       
        public ActionResult Create([Bind("Id,CategoryId, content,Title,time")] News news)
        {
            if (ModelState.IsValid)
            {
                
                _context.News.Add(news);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(news);
        }

        // GET: News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                return NotFound();
            }
            News news = _context.News.Find(id);
            if (news != null)
            {
                return NotFound();
            }
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,content,Title,images,time")] News news)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(news).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            News news = _context.News.Find(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = _context.News.Find(id);
            _context.News.Remove(news);
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
