using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes
{
    public abstract class Hero
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }

        public string Class { get; set; }

        /*
        im thinking having two types of stats, Base which is the stats the hero is initialized + the stats from stat growth.
        and then the Stats Strength, Dexterity, Intelligence could be calculated as equipment with stat enchantments was added.

        public int BaseStrength { get; set; }
        public int BaseDexterity { get; set; }
        public int BaseIntelligence { get; set; }
        */

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public List<Enum> ValidWeaponTypes { get; set; }
        public List<Enum> ValidArmorTypes { get; set; }
        public Dictionary<Enum, object> Equipment { get; set; }


        public Hero(string name)
        {
            Name = name;
            Level = 1;
            Equipment = new Dictionary<Enum, object>();
        }

        public void LevelUp(int strengthGrowth, int dexterityGrowth, int intelligenceGrowth)
        {
            Level++;
            Strength += strengthGrowth;
            Dexterity += dexterityGrowth;
            Intelligence += intelligenceGrowth;
        }

        public void Equip(Enum equipmentType, object equipment)
        {
            if (ValidWeaponTypes.Contains(equipmentType) || ValidArmorTypes.Contains(equipmentType))
            {
                Equipment[equipmentType] = equipment;
            }
        }

        public int Damage()
        {
            /* 
             * Should return a value we can use in Display, and if we code in combat.
             * Hero damage = WeaponDamage * (1 + DamagingAttribute/100)
             */
            return 10;
        }

        public void TotalAttributes()
        {
            /*
            Requires a split between base stats and overall stats

            would end up with something like

            OverallStrength = BaseStrength + Strength, where basestrength is gained from initialization and levelups, and strength is gained from equipment.
            */

        }

        public string Display()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name: " + Name + "\n");
            sb.Append("Class: " + Class + "\n");
            sb.Append("Level: " + Level + "\n");
            sb.Append("Total Strength: " + Strength + "\n");
            sb.Append("Total Dexterity: " + Dexterity + "\n");
            sb.Append("Total Intelligence: " + Intelligence + "\n");
            sb.Append("Damage: " + Damage() + "\n");
            return sb.ToString();
        }



    }
}
