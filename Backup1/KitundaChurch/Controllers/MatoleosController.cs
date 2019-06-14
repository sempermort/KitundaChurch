using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KitundaChurch.Models;
using System.Collections.Generic;
using Rotativa.AspNetCore;
using System;

namespace KitundaChurch.Controllers
{

    public class MatoleosController : Controller
    {
        public int PageSize { get; set; } = 4;

        //const string SessionKeyDate = "_Date";
        private readonly KitundaChurchContext _context;

        public MatoleosController(KitundaChurchContext context)
        {
            _context = context;
        }

        // GET: Matoleos
        public IActionResult Index()

        {
            Matoleo matoleo = new Matoleo();

            var listed = _context.Matoleo.Include(m => m.ChurchMembers).Include(m => m.mengineyo).GroupBy(x => x.Savetime).First().ToList();


            ViewBag.Mengineyo = listed.Select(n=>n.mengineyo).ToList();
            ViewBag.sum1 = listed.Sum(n => n.sadakaBk);
            ViewBag.sum2 = listed.Sum(n => n.sadakaConf);
            ViewBag.sum3 = listed.Sum(n => n.Zaka);
            ViewBag.sum4 = listed.Sum(n => n.Total);
            ViewBag.sum5 = listed.Sum(n => n.MpangoKanisa);
            ViewBag.sum6 = listed.Sum(n => n.sadakaMakambi);
            ViewBag.sum7 = listed.Sum(n => n.sadakaMajengo);

            return View(listed);
        }

        [HttpPost]
        public IActionResult Index(Matoleo matoleo)
        {
            var listed = _context.Matoleo.Include(m => m.ChurchMembers).Include(n => n.mengineyo).Where(n => n.Savetime == matoleo.Savetime).ToList();
            ViewBag.sum1 = listed.Sum(n => n.sadakaBk);
            ViewBag.sum2 = listed.Sum(n => n.sadakaConf);
            ViewBag.sum3 = listed.Sum(n => n.Zaka);
            ViewBag.sum4 = listed.Sum(n => n.Total);
            ViewBag.sum5 = listed.Sum(n => n.MpangoKanisa);
            ViewBag.sum6 = listed.Sum(n => n.sadakaMakambi);
            ViewBag.sum7 = listed.Sum(n => n.sadakaMajengo);
            ViewBag.mengineyo = listed.Select(n => n.mengineyo).ToList();
            return View(listed);
        }
        // GET: Matoleos/Details/5
        public async Task<IActionResult> DetailsAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matoleo = await _context.Matoleo
                .Include(m => m.ChurchMembers)
                .SingleOrDefaultAsync(m => m.MatoleoId == id);
            if (matoleo == null)
            {
                return NotFound();
            }

            return View(matoleo);
        }
        //[HttpGet]
        //public IActionResult GetUser()
        //{

        //    return PartialView();
        //}
        //[HttpPost]

        public JsonResult GetUser(string Name)
        {



            var members = (from n in _context.ChurchMembers
                           where n.Name.StartsWith(Name)
                           select n.Name);

            //var Name = members.Name;


            return new JsonResult(members);

        }
        public async Task<IActionResult> RegMemberAsync(string searchString)
        {
            ChurchMembers members = new ChurchMembers();
            members.Name = searchString;
            if (ModelState.IsValid)
            {
                _context.Add(members.Name);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return PartialView();
        }
        [HttpGet]
        // GET: Matoleos/Create
        public IActionResult Create()
        {
            Matoleo matoleo = new Matoleo();
            //ViewData["Savetime"] = SessionKeyDate;


            return View(matoleo);
        }

        // POST: Matoleos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(Matoleo matoleo, IList<Mengineyo> mengineyo)
        {
            //HttpContext.Session.Set<DateTime>(SessionKeyDate, matoleo.Savetime);

            //var meng = formCollectiom.Contains("Name")
            if (ModelState.IsValid)
            {
                var exists = _context.Matoleo.Include(v => v.ChurchMembers).AsNoTracking().Any(x => x.ChurchMembers.Name == matoleo.ChurchMembers.Name);
                if (exists)
                {
                    _context.Update(matoleo);

                }

                _context.Add(matoleo);
                await _context.SaveChangesAsync();
                await NudiaAsync(matoleo, mengineyo);

                return RedirectToAction(nameof(Index));
            }
            ViewData["ChurchMembersId"] = new SelectList(_context.ChurchMembers, "ChurchMembersId", "ChurchMembersId", matoleo.ChurchMembersId);
            return View(matoleo);
        }

        public async Task NudiaAsync(Matoleo matoleo, IList<Mengineyo> mengineyo)
        {
            foreach (var m in mengineyo)
            {

                Mengineyo mengi = new Mengineyo()
                {
                    descr = m.descr,
                    Amount = m.Amount
                };
                mengi.MatoleoId = matoleo.MatoleoId;
                _context.Add(mengi);
                await _context.SaveChangesAsync();
            }
        }
        [HttpGet]
        // GET: Matoleos/Edit/5
        public async Task<IActionResult> EditAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matoleo = await _context.Matoleo.Include(n => n.ChurchMembers).SingleAsync(m => m.MatoleoId == id);
            if (matoleo == null)
            {
                return NotFound();
            }
            ViewData["ChurchMembersId"] = new SelectList(_context.ChurchMembers, "ChurchMembersId", "ChurchMembersId", matoleo.ChurchMembersId);
            ViewData["MatoleoId"] = new SelectList(_context.Matoleo, "MatoleoId", "MatoleoId", matoleo.MatoleoId);
            return View(matoleo);
        }

        // POST: Matoleos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int id, Matoleo matoleo)
        {
            if (id != matoleo.MatoleoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matoleo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatoleoExists(matoleo.MatoleoId))
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
            ViewData["ChurchMembersId"] = new SelectList(_context.ChurchMembers, "ChurchMembersId", "ChurchMembersId", matoleo.ChurchMembersId);
            ViewData["MatoleoId"] = new SelectList(_context.Matoleo, "MatoleoId", "MatoleoId", matoleo.MatoleoId);
            return View(matoleo);
        }

        public IActionResult SummaryAsync(Matoleo matoleo,  int Page = 1)
        {
            
            var listed = _context.Matoleo.AsNoTracking().Where(n=>n.Savetime==matoleo.Savetime).Include(b => b.ChurchMembers);


            //.Skip((productPage - 1) * PageSize)
            //.Take(PageSize);
            var vai = ReflectionIT.Mvc.Paging.PaginList<Matoleo>.CreateAsync(listed, PageSize, Page, matoleo.Savetime.ToString(), matoleo.Savetime.ToString());
            vai.RouteValue = new Microsoft.AspNetCore.Routing.RouteValueDictionary
            {
                {matoleo.Savetime.ToString() , matoleo.Savetime}
            };
            ViewBag.sum1 = vai.Sum(n => n.sadakaBk);
            ViewBag.sum2 = vai.Sum(n => n.sadakaConf);
            ViewBag.sum3 = vai.Sum(n => n.Zaka);
            ViewBag.sum4 = vai.Sum(n => n.Total);
            ViewBag.sum5 = vai.Sum(n => n.MpangoKanisa);
            ViewBag.sum6 = vai.Sum(n => n.sadakaMakambi);
            ViewBag.sum7 = vai.Sum(n => n.sadakaMajengo);
            return View(vai);
        }

        // GET: Matoleos/Delete/5
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matoleo = await _context.Matoleo
                .Include(m => m.ChurchMembers)
                .SingleOrDefaultAsync(m => m.MatoleoId == id);
            if (matoleo == null)
            {
                return NotFound();
            }

            return View(matoleo);
        }

        // POST: Matoleos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedAsync(Matoleo mato)
        {
            var matoleo = await _context.Matoleo.SingleOrDefaultAsync(m => m.MatoleoId ==mato.MatoleoId);
            _context.Matoleo.Remove(matoleo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatoleoExists(int id)
        {
            return _context.Matoleo.Any(e => e.MatoleoId == id);
        }



        //public static class SessionExtensions
        //{
        //    public static void Set<T>(this ISession session, string key, T value)
        //    {
        //        session.SetString(key, JsonConvert.SerializeObject(value));
        //    }
        //    public static T Get<T>(this ISession session, string key)
        //    {
        //        var value = session.GetString(key);
        //        return value == null ? default(T) :
        //                              JsonConvert.DeserializeObject<T>(value);
        //    }
        //}
        // GET: Matoleos
        //public IActionResult Report()

        //{

        //    return View();
        //}

        //[HttpPost]
        public IActionResult Report(/*FormCollection fc*/)
        {
          
            //var dat1 = fc["Savetime1"];
            //var dat2 = fc["Savetime2"];
            var listed = _context.Matoleo.GroupBy(x => x.Savetime);
            ViewBag.tar = listed.Select(n => n.FirstOrDefault()).Select(m => m.Savetime);

          ViewBag.A= listed.Select(n => n.Sum(m => m.sadakaConf+m.Zaka+m.sadakaMakambi)).ToList();
            ViewBag.B = listed.Select(n => n.Sum(m => m.sadakaBk + m.sadakaMajengo+m.MpangoKanisa)).ToList();
            ViewBag.sumBk = listed.Select(n=>n.Sum(m=>m.sadakaBk)).ToList();
            ViewBag.sumBKf = listed.Sum(n => n.Sum(m => m.sadakaBk));
             ViewBag.sumConf = listed.Select(n => n.Sum(m => m.sadakaConf)).ToList();
            ViewBag.Conff = listed.Sum(n => n.Sum(m => m.sadakaConf));
                ViewBag.sumZaka = listed.Select(n => n.Sum(m => m.Zaka)).ToList();
            ViewBag.SumZakaf = listed.Sum(n => n.Sum(m => m.Zaka));
             ViewBag.sumTotal = listed.Select(n => n.Sum(m => m.Total)).ToList();
            ViewBag.SumTotalf = listed.Sum(n => n.Sum(m => m.Total));
             ViewBag.sumMp = listed.Select(n => n.Sum(m => m.MpangoKanisa)).ToList();
            ViewBag.SumMpf = listed.Sum(n => n.Sum(m => m.MpangoKanisa));
             ViewBag.sumMbi = listed.Select(n => n.Sum(m => m.sadakaMakambi)).ToList();
            ViewBag.SumMbif = listed.Sum(n => n.Sum(m => m.sadakaMakambi));
             ViewBag.sumNgo = listed.Select(n => n.Sum(m => m.sadakaMajengo)).ToList();
            ViewBag.SumNgof = listed.Sum(n => n.Sum(m => m.sadakaMajengo));


            //ViewBag.mengineyo = listed.OrderBy(g => g.Sum(n => n.mengineyo).ToList();
            return View(listed);
        }

        public IActionResult PrintViewToPdf()
        {

            return new ViewAsPdf("Report");
        }



        // GET: Matoleos/Details/5
    }
}
