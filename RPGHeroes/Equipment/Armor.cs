using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Equipment
{



    public enum ArmorType
    {
        Cloth, Leather, Mail, Plate
    }

    public class Armor : Equipment
    {
        public EquipmentSlot Slot { get; set; }

        public ArmorType Type { get; set; }

        public Armor(string name, int defense, int levelRequirement, EquipmentSlot slot, ArmorType type) : base(name, 0, defense, levelRequirement)
        {
            Slot = slot;
            Type = type;
        }
    }
}
