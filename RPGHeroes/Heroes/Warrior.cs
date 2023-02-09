using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes
{

    public enum WarriorWeapons
    {
        Axe, Hammer, Sword
    }

    public enum WarriorArmor
    {
        Mail, Plate
    }

    public class Warrior : Hero
    {
        public Warrior(string name) : base(name)
        {
            ValidWeaponTypes = new List<Enum>()
            {
                WarriorWeapons.Axe, WarriorWeapons.Hammer, WarriorWeapons.Sword
            };

            ValidArmorTypes = new List<Enum>()
            {
                WarriorArmor.Mail, WarriorArmor.Plate
            };

            Strength = 5;
            Dexterity = 2;
            Intelligence = 1;
            Class = "Warrior";

        }

        public void levelUpAttributes()
        {
            base.LevelUp(3, 2, 1);
        }

    }
}
