using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes
{

    public enum RangerWeapons
    {
        Bow
    }

    public enum RangerArmor
    {
        Leather, Mail
    }

    public class Ranger : Hero
    {
        public Ranger(string name) : base(name)
        {
            ValidWeaponTypes = new List<Enum>()
            {
                RangerWeapons.Bow
            };

            ValidArmorTypes = new List<Enum>()
            {
                RangerArmor.Leather, RangerArmor.Mail
            };

            Strength = 1;
            Dexterity = 7;
            Intelligence = 1;
            Class = "Ranger";


        }

        public void levelUpAttributes()
        {
            base.LevelUp(1, 5, 1);
        }

    }
}
