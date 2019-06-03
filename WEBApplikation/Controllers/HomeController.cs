using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WEBApplikation.DAL;
using WEBApplikation.Models;

namespace WEBApplikation.Controllers
{
    public class HomeController : Controller
    {
        private GardenerRepository database;
        public HomeController()
        {
            database = new GardenerRepository();
            database.CreateDatabase();
        }
        public IActionResult Index()
        {
            return RedirectToAction("List","Location");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
