using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Equipment
{
    public abstract class Equipment
    {
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int LevelRequirement { get; set; }

        public Equipment(string name, int attack, int defense, int levelRequirement)
        {
            Name = name;
            Attack = attack;
            Defense = defense;
            LevelRequirement = levelRequirement;
        }

    }



}
