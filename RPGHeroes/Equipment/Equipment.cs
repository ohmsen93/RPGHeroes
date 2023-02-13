using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGHeroes.Heroes;

namespace RPGHeroes.Equipment
{

    public enum EquipmentSlot
    {
        Head, Chest, Wrist, Hands, Waist, Legs, Feet, MainHand, OffHand
    }
    public abstract class Equipment
    {
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int LevelRequirement { get; set; }
        
        /* Grab HeroAttributes to utilize the Attribute logic */
        public HeroAttributes EnchantmentAttributes { get; set; }


        public Equipment(string name, int attack, int defense, int levelRequirement)
        {
            Name = name;
            Attack = attack;
            Defense = defense;
            LevelRequirement = levelRequirement;

            /* Create a new instance of Hero attribute for the specific Equipment */

            /* This is where im at, im wondering if i should use an object in the factory/weapon/armor to handle Str, Dex and Int together called enchantmentAttributes or the like ? */

            EnchantmentAttributes = new HeroAttributes();
        }

    }



}
