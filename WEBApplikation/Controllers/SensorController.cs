using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEBApplikation.DAL;
using WEBApplikation.Models;

namespace WEBApplikation.Controllers
{
    public class SensorController : Controller
    {
        private GardenerRepository database;

        public SensorController()
        {
            database = new GardenerRepository();
        }

        public IActionResult List(int id)
        {
            return View(database.GetSensorsByLocation(id).Result);
        }

        public IActionResult All()
        {
            return View(database.GetSensors().Result);
        }

        public IActionResult Create(Sensor sensor)
        {
            database.AddSensor(sensor).Wait();
            return RedirectToAction("Details", "Location", sensor.LocationId);
        }
    }
}