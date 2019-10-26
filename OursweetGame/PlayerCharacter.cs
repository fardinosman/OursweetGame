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

        public void Attack(PlayerCharacter target, int damageAmount)
        {
            target.HP = target.HP - damageAmount;
        }
    }
}