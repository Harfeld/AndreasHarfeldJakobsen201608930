using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEBApplikation.DAL;
using WEBApplikation.Models;

namespace WEBApplikation.Controllers
{
    public class LocationController : Controller
    {
        private GardenerRepository database;

        public LocationController()
        {
            database = new GardenerRepository();
        }

        public IActionResult Index()
        {
            return View(database.GetLocations().Result);
        }

        public IActionResult List()
        {
            return View(database.GetLocations().Result);
        }

        public IActionResult Details(int id)
        {
            return View(database.GetLocationById(id).Result);
        }

        public IActionResult SearchList(string searchInput)
        {
            return searchInput != null ?
                View("List", database.GetLocations().Result.Where(l => l.Name.ToLower().StartsWith(searchInput.ToLower()))):
                View("List", database.GetLocations().Result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}