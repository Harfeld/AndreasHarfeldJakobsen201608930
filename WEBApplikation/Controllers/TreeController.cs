using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEBApplikation.DAL;

namespace WEBApplikation.Controllers
{
    public class TreeController : Controller
    {
        private GardenerRepository database;
        public TreeController()
        {
            database = new GardenerRepository();
        }
        public IActionResult List(int id)
        {
            return View(database.GetTreesByLocation(id).Result);
        }
    }
}