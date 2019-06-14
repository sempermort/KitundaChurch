using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KitundaChurch.Models;


namespace KitundaChurch.Controllers
{
    public class ChurchMembersController : Controller
    {
        private readonly KitundaChurchContext _context;

        public ChurchMembersController(KitundaChurchContext context)
        {
            _context = context;
        }

        // GET: ChurchMembers
        public async Task<IActionResult> IndexAsync()
        {
            return View(await _context.ChurchMembers.ToListAsync());
        }

        // GET: ChurchMembers/Details/5
        public async Task<IActionResult> DetailsAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var churchMembers = await _context.ChurchMembers
                .SingleOrDefaultAsync(m => m.ChurchMembersId == id);
            if (churchMembers == null)
            {
                return NotFound();
            }

            return View(churchMembers);
        }

        // GET: ChurchMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChurchMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync([Bind("ChurchMembersId,Name,FamilyName,Zone,MaritalStatus,Resident,DarasaSS,MemberShipNo,PhoneNo,Status")] ChurchMembers churchMembers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(churchMembers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexAsync));
            }
            return View(churchMembers);
        }

        // GET: ChurchMembers/Edit/5
        public async Task<IActionResult> EditAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var churchMembers = await _context.ChurchMembers.SingleOrDefaultAsync(m => m.ChurchMembersId == id);
            if (churchMembers == null)
            {
                return NotFound();
            }
            return View(churchMembers);
        }

        // POST: ChurchMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int id, [Bind("ChurchMembersId,Name,FamilyName,Zone,MaritalStatus,Resident,DarasaSS,MemberShipNo,PhoneNo,Status")] ChurchMembers churchMembers)
        {
            if (id != churchMembers.ChurchMembersId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(churchMembers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChurchMembersExists(churchMembers.ChurchMembersId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexAsync));
            }
            return View(churchMembers);
        }

        // GET: ChurchMembers/Delete/5
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var churchMembers = await _context.ChurchMembers
                .SingleOrDefaultAsync(m => m.ChurchMembersId == id);
            if (churchMembers == null)
            {
                return NotFound();
            }

            return View(churchMembers);
        }

        // POST: ChurchMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedAsync(int id)
        {
            var churchMembers = await _context.ChurchMembers.SingleOrDefaultAsync(m => m.ChurchMembersId == id);
            _context.ChurchMembers.Remove(churchMembers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexAsync));
        }

        private bool ChurchMembersExists(int id)
        {
            return _context.ChurchMembers.Any(e => e.ChurchMembersId == id);
        }
    }
}
