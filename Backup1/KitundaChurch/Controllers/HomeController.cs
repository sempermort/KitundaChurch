using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KitundaChurch.Models;


namespace KitundaChurch.Controllers
{
    public class HomeController : Controller
    {
        private readonly KitundaChurchContext _context;
        public HomeController(KitundaChurchContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Intermediate(int id)
        {
           
            

            return ViewComponent("News",id);
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
