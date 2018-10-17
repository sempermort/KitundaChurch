using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KitundaChurch.Models;

namespace KitundaChurch.Controllers
{
    public class MatumiziController : Controller
    {
        private readonly KitundaChurchContext _context;

        public MatumiziController(KitundaChurchContext context)
        {
            _context = context;
        }

        // GET: Matumizi
        public async Task<IActionResult> IndexAsync()
        {
            var kitundaChurchContext = _context.Matumizi.Include(m => m.department);
            return View(await kitundaChurchContext.ToListAsync());
        }

        // GET: Matumizi/Details/5
        public async Task<IActionResult> DetailsAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matumizi = await _context.Matumizi
                .Include(m => m.department)
                .SingleOrDefaultAsync(m => m.MatumiziId == id);
            if (matumizi == null)
            {
                return NotFound();
            }

            return View(matumizi);
        }

        // GET: Matumizi/Create
        public IActionResult Create()
        {
            ViewBag.Depart = new SelectList(_context.Department.Select(n => n.Name));
            //ViewData["DepartmentId"] = new SelectList(_context.Set<Department>(), "DepartmentId", "DepartmentId");
            return View();
        }

        // POST: Matumizi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(/*[Bind("MatumiziId,Receiver,Amount,FormNo,DepartmentId")]*/ Matumizi matumizi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matumizi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexAsync));
            }
          
            return View(matumizi);
        }

        // GET: Matumizi/Edit/5
        public async Task<IActionResult> EditAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matumizi = await _context.Matumizi.SingleOrDefaultAsync(m => m.MatumiziId == id);
            if (matumizi == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Set<Department>(), "DepartmentId", "DepartmentId", matumizi.DepartmentId);
            return View(matumizi);
        }

        // POST: Matumizi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int id, /*[Bind("MatumiziId,Receiver,Amount,FormNo,DepartmentId")]*/ Matumizi matumizi)
        {
            if (id != matumizi.MatumiziId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matumizi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatumiziExists(matumizi.MatumiziId))
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
            ViewData["DepartmentId"] = new SelectList(_context.Set<Department>(), "DepartmentId", "DepartmentId", matumizi.DepartmentId);
            return View(matumizi);
        }

        // GET: Matumizi/Delete/5
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matumizi = await _context.Matumizi
                .Include(m => m.department)
                .SingleOrDefaultAsync(m => m.MatumiziId == id);
            if (matumizi == null)
            {
                return NotFound();
            }

            return View(matumizi);
        }

        // POST: Matumizi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedAsync(int id)
        {
            var matumizi = await _context.Matumizi.SingleOrDefaultAsync(m => m.MatumiziId == id);
            _context.Matumizi.Remove(matumizi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexAsync));
        }

        private bool MatumiziExists(int id)
        {
            return _context.Matumizi.Any(e => e.MatumiziId == id);
        }
    }
}
