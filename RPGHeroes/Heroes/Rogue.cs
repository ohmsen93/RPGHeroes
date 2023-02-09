using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes
{

    public enum RogueWeapons
    {
        Dagger, Sword
    }

    public enum RogueArmor
    {
        Leather, Mail
    }

    public class Rogue : Hero
    {
        public Rogue(string name) : base(name)
        {
            ValidWeaponTypes = new List<Enum>()
            {
                RogueWeapons.Dagger, RogueWeapons.Sword
            };

            ValidArmorTypes = new List<Enum>()
            {
                RogueArmor.Leather, RogueArmor.Mail
            };

            Strength = 2;
            Dexterity = 6;
            Intelligence = 1;
            Class = "Rogue";

        }

        public void levelUpAttributes()
        {
            base.LevelUp(1, 4, 1);
        }

    }
}
