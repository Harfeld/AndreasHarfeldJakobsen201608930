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
        private SignInManager<IdentityUser> sm;
        private GardenerRepository database;
        public HomeController(SignInManager<IdentityUser> _sm)
        {
            sm = _sm;
            database = new GardenerRepository();
            database.CreateDatabase();
        }
        public IActionResult Index()
        {
            if (sm.IsSignedIn(User))
            {
                return RedirectToAction("List", "Location");
            }
            else
            {
                return View();
            }
            
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
