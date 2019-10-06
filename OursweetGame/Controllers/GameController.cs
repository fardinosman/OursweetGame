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
            Person person= new Person();
            person.Name = Name;
            person.Job = Job;
            ViewBag.Age = Age.ToString();
            ViewBag.Job = Job;

            GameDatabaseEntities gameDatabaseEntities = new GameDatabaseEntities();
            gameDatabaseEntities.Person.Add(person);

            gameDatabaseEntities.SaveChanges();

            return RedirectToAction("DisplayCharacter");
        }
        public ActionResult DisplayCharacter()
        {
            GameDatabaseEntities gameDatabaseEntities = new GameDatabaseEntities();
            var d = gameDatabaseEntities.Person.ToList();
            //PersonEntities entities = new PersonEntities();
            //var d = entities.Human.ToList();


            return View("DisplayCharacter",d);

           
        }

     
        public ActionResult KillCharacter(int ID)
        {
            GameDatabaseEntities db = new GameDatabaseEntities();
            var personKill = db.Person.Where(x => x.ID == ID).FirstOrDefault();
           
            //var personFound = db.Person.Find(ID);
          

            if (personKill != null)
            {
                db.Person.Remove(personKill);
                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("NoUser");
            }



            return View("KillCharacter");

           
        }
       // EditCharacter
      
        public ActionResult EditCharacter(int ID)
        {
            GameDatabaseEntities gameDatabaseEntities = new GameDatabaseEntities();
            var personFound = gameDatabaseEntities.Person.Find(ID);
            return View("EditCharacter",personFound);
        }
        [HttpPost]
        public ActionResult EditCharacter(Person person)
        {
            GameDatabaseEntities gameDatabaseEntities = new GameDatabaseEntities();
            /*
             1- Get hold of entry (probably using ID
              2- Modify that entry
              3- save changes
             */

           var personToUdpdate =  gameDatabaseEntities.Person.Find(person.ID);
            personToUdpdate.Name = person.Name;
            personToUdpdate.Job = person.Job;
            personToUdpdate.Age = person.Age;

            gameDatabaseEntities.SaveChanges();



            return RedirectToAction("DisplayCharacter");
        }
        public ActionResult NoUser()
        {
          

            return View();
        }
        [HttpPost]
        public ActionResult KillCharacter(string Name)
        {
            //GameDatabaseEntitie db = new PersonEntities();
            GameDatabaseEntities db = new GameDatabaseEntities();
            var personKill = db.Person.Where(x => x.Name == Name).FirstOrDefault();

            if (personKill != null)
            {
                db.Person.Remove(personKill);
                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("NoUser");
            }





            return RedirectToAction("DisplayCharacter");
            //Database
            /*
             Get what you want to manipulate
             */

        }
    }
}