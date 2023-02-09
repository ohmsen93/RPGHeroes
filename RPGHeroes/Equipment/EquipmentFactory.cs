using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Equipment
{
    public class EquipmentFactory
    {
        private static readonly Dictionary<string, WeaponBaseType> WeaponBaseTypes = new Dictionary<string, WeaponBaseType>
        {
            { "Axes", WeaponBaseType.Axe },
            { "Bows", WeaponBaseType.Bow },
            { "Daggers", WeaponBaseType.Dagger },
            { "Hammers", WeaponBaseType.Hammer },
            { "Staffs", WeaponBaseType.Staff },
            { "Swords", WeaponBaseType.Sword },
            { "Wands", WeaponBaseType.Wand }
        };

        private static readonly Dictionary<string, ArmorSlot> ArmorSlots = new Dictionary<string, ArmorSlot>
        {
            { "Head", ArmorSlot.Head },
            { "Chest", ArmorSlot.Chest },
            { "Wrist", ArmorSlot.Wrist },
            { "Hands", ArmorSlot.Hands },
            { "Waist", ArmorSlot.Waist },
            { "Legs", ArmorSlot.Legs },
            { "Feet", ArmorSlot.Feet }
        };

        public Equipment CreateEquipment(string name, int attack, int defense, int levelRequirement, string type, string subType, string armorType = null)
        {
            if (type == "Weapon")
            {
                return new Weapon(name, attack, levelRequirement, WeaponBaseTypes[subType]);
            }
            else if (type == "Armor")
            {
                return new Armor(name, defense, levelRequirement, ArmorSlots[subType], (ArmorType)Enum.Parse(typeof(ArmorType), armorType));
            }
            else
            {
                return null;
            }
        }

    }
}
