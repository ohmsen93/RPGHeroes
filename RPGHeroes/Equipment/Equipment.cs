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
        public Attributes EnchantmentAttributes { get; set; }


        public Equipment(string name, int attack, int defense, int levelRequirement, int strengthEnchantment, int dexterityEnchantment, int intelligenceEnchantment)
        {
            Name = name;
            Attack = attack;
            Defense = defense;
            LevelRequirement = levelRequirement;

            EnchantmentAttributes = new Attributes();

            EnchantmentAttributes.Strength = strengthEnchantment;
            EnchantmentAttributes.Dexterity = dexterityEnchantment;
            EnchantmentAttributes.Intelligence = intelligenceEnchantment;

        }

    }



}
