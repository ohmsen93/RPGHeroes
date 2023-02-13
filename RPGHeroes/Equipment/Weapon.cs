using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Equipment
{
    public enum WeaponBaseType
    {
        Axe, Bow, Dagger, Hammer, Staff, Sword, Wand
    }

    public class Weapon : Equipment
    {
        public WeaponBaseType BaseType { get; set; }

        public EquipmentSlot Slot { get; set; }


        public Weapon(string name, int attack, int levelRequirement, EquipmentSlot slot, WeaponBaseType baseType) : base(name, attack, 0, levelRequirement)
        {
            Slot = slot;
            BaseType = baseType;
        }

    }
}
