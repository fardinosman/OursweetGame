using OursweetGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OursweetGame.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            GameDatabaseEntities1 gameDatabase = new GameDatabaseEntities1();

            var chracter = gameDatabase.Character.Find(1);
            var w = chracter.Weapons;


            return View();
        }
        public ActionResult Roaster()
        {
            GameDatabaseEntities1 gameDatabaseEntities = new GameDatabaseEntities1();

            List<Person> peopleList = gameDatabaseEntities.Person.ToList();
            
            return View("RoasterPage",peopleList);
        }
        public ActionResult CreatePerson(Person p)
        {
            return View();
        }
    }
}