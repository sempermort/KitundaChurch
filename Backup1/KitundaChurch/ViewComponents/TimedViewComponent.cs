using KitundaChurch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitundaChurch.ViewComponents
{
    public class TimedViewComponent:ViewComponent
    {
        private readonly KitundaChurchContext _context;

        public TimedViewComponent(KitundaChurchContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var listed = _context.Matoleo.GroupBy(x => x.Savetime).Select(x => x.FirstOrDefault()).ToList();
            ViewBag.Timed = new SelectList(listed.Select(n=>n.Savetime));
           Matoleo matoleo = new Matoleo();


            return View(matoleo);
        }
    }
}
