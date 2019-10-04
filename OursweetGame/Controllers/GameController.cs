using OursweetGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OursweetGame.Controllers
{
    public class GameController : Controller
    {

        public ActionResult Index()
        {
            return View();

        }
        public ActionResult CreateCharacter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProcessCreateCharacter(string Name, int Age,string Job)
        {
            string character = Name;
            //listPerson.Add(new Person { Name=Name, Age=Age, Job=Job });
            OursweetGame.Models.Human human = new Human();
            human.Name = Name;
            human.Job = Job;
            ViewBag.Age = Age.ToString();
            ViewBag.Job = Job;

            PersonEntities entities = new PersonEntities();
            entities.Human.Add(human);
            
            entities.SaveChanges();

            return null;
        }
        public ActionResult DisplayCharacter()
        {

            PersonEntities entities = new PersonEntities();
            var d = entities.Human.ToList();

            return View("DisplayCharacter",d);

           
        }
    }
}