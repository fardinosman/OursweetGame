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
            Person p = new Person();
            return View(p);
        }
        [HttpPost]
        public ActionResult ProcessCreateCharacter(Person person)
        {
            //string character = Name;
            ////listPerson.Add(new Person { Name=Name, Age=Age, Job=Job });
            //Person person= new Person();
            //person.Name = Name;
            //person.Job = Job;
            //ViewBag.Age = Age.ToString();
            //ViewBag.Job = Job;

            GameDatabaseEntities1 gameDatabaseEntities = new GameDatabaseEntities1();
            gameDatabaseEntities.Person.Add(person);

            gameDatabaseEntities.SaveChanges();

            return RedirectToAction("DisplayCharacter");
        }
        public ActionResult DisplayCharacter()
        {
            GameDatabaseEntities1 gameDatabaseEntities = new GameDatabaseEntities1();
            var d = gameDatabaseEntities.Person.ToList();
            //PersonEntities entities = new PersonEntities();
            //var d = entities.Human.ToList();

         
            return View("DisplayCharacter",d);

           
        }
       
      // EditCharacter    
        public ActionResult EditCharacter(int ID)
        {
            GameDatabaseEntities1 gameDatabaseEntities = new GameDatabaseEntities1();
            var personFound = gameDatabaseEntities.Person.Find(ID);
            return View("EditCharacter",personFound);
        }
        [HttpPost]
        public ActionResult EditCharacter(Person person)
        {
            GameDatabaseEntities1 gameDatabaseEntities = new GameDatabaseEntities1();
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
     
        public ActionResult KillCharacter(int ID)
        {
            GameDatabaseEntities1 db = new GameDatabaseEntities1();
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



            return RedirectToAction("DisplayCharacter");


        }
      
        [HttpPost]
        public ActionResult KillCharacter(string Name)
        {
            //GameDatabaseEntitie db = new PersonEntities();
            GameDatabaseEntities1 db = new GameDatabaseEntities1();
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
        public ActionResult Arena()
        {
            var player1 = new PlayerCharacter
            {
                Job = "Paladin",
                HP = 15,
                Weapon = "Mace",
                Heals = 1
            };

            var player2 = new PlayerCharacter
            {
                Job = "Ranger",
                HP = 15,
                Weapon = "Bow",
                Heals = 1
            };

            do
            {
                player1.Attack(player2);
                player2.Attack(player1);
            } while (player1.HP> 0 && player2.HP>0);
            string winner = "";
            if (player1.HP > 0)
            {
                winner = "Player1";
            }
            else if (player1.HP<1 && player2.HP <1)
            {
                winner = "Draw";
            }
            else
            {
                winner = "player2";
            }
            ViewBag.Winner = winner;
          
            return View();
        }
    }
}