using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes
{

    public enum MageWeapons
    {
        Staff, Wand
    }

    public enum MageArmor
    {
        Cloth
    }

    public class Mage : Hero
    {
        public Mage(string name) : base(name)
        {
            ValidWeaponTypes = new List<Enum>()
            {
                MageWeapons.Staff, MageWeapons.Wand
            };

            ValidArmorTypes = new List<Enum>()
            {
                MageArmor.Cloth
            };

            Strength = 1;
            Dexterity = 1;
            Intelligence = 8;
            Class = "Mage";

        }

        public void levelUpAttributes()
        {
            base.LevelUp(1, 1, 5);
        }

    }
}
