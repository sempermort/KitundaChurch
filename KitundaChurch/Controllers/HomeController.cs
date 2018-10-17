using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KitundaChurch.Models;
using Microsoft.EntityFrameworkCore;
using KitundaChurch.Migrations;

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
