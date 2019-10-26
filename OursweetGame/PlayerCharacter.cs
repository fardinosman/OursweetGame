using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OursweetGame
{
    public class PlayerCharacter
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public int Age { get; set; }
        public string Towel { get; set; }
        public string Race { get; set; }
        public int HP { get; set; }
        public string Level { get; set; }
        public string Spell { get; set; }
        public string MP { get; set; }
        public int Gold { get; set; }
        public string Weapon { get; set; }
        public int Heals { get; set; }

        public void Attack(PlayerCharacter target)
        {
            Random r = new Random();
            int axedamage = r.Next(0, 13);
            int swordDamage = r.Next(1, 9);
            int maceDamage = r.Next(1, 9);
            int bowDamage = r.Next(1, 7);
            if (Weapon =="Axe")
            {
                target.HP = target.HP - axedamage;
            }
            else if (Weapon == "Sword")
            {
                target.HP = target.HP - swordDamage;
            }
            else if (Weapon == "Mace")
            {
                target.HP = target.HP - maceDamage;
            }
            else if (Weapon == "Bow")
            {
                target.HP = target.HP - bowDamage;
            }

        }
        public void HealSelf()
        {
            if (Heals > 0)
            {
                HP = 15;
            }
            Heals = Heals - 1;
           
        }
    }
}