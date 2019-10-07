using OursweetGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OursweetGame.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateCar()
        {
            Car car = new Car();

            
            return View(car);
        }
        [HttpPost]
        public ActionResult CreateCar(string Color, string Make, int Year)
        {
            Car car = new Car();

            car.Color = Color;
            car.Make = Make;
            car.Year = Year;
            return null;
        }
    }
}