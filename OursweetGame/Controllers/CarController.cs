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
        public ActionResult CreateCar(Car c)
        {
            Car car = new Car();
            int currentYear = DateTime.Now.Year;
            int age =  currentYear - c.Year;
         
        
            if (age > 50) 
            {
                c.Make = "OLD " + c.Make;
                
            }
            if (age >10 && age<20)
            {
                c.Make = "Mediom " + c.Make;
            }
            if (age <=5)
            {
                c.Make = "New " + c.Make;
            }
            car.Make = c.Make;
            car.Color = c.Color;
            car.Year = c.Year;
           
            
          
            return View("DisplayCar",null,car);
        }
      
    }
}