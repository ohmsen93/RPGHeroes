using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGHeroes.Equipment;

namespace RPGHeroes.Heroes
{
    public abstract class Hero
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public abstract string CharacterClass { get; }

        /*
        im thinking having two types of stats, Base which is the stats the hero is initialized + the stats from stat growth.
        and then the Stats Strength, Dexterity, Intelligence could be calculated as equipment with stat enchantments was added.

        public int BaseStrength { get; set; }
        public int BaseDexterity { get; set; }
        public int BaseIntelligence { get; set; }
        */
        public HeroAttributes Attributes { get; set; }

        public HeroAttributeGrowth AttributeGrowth { get; set; }
        public List<WeaponBaseType> ValidWeaponTypes { get; set; }
        public List<ArmorType> ValidArmorTypes { get; set; }
        public Dictionary<EquipmentSlot, Equipment.Equipment> Equipment { get; set; }


        public Hero(string name)
        {
            Name = name;
            Level = 1;
            Equipment = new Dictionary<EquipmentSlot, Equipment.Equipment>();
            Attributes = new HeroAttributes();
            AttributeGrowth = new HeroAttributeGrowth();
        }

        public virtual void LevelUp()
        {
            Level++;
            Attributes.Strength += AttributeGrowth.StrengthGrowth;
            Attributes.Dexterity += AttributeGrowth.DexterityGrowth;
            Attributes.Intelligence += AttributeGrowth.IntelligenceGrowth;
        }

        public void Equip(EquipmentSlot equipmentType, Equipment.Equipment equipment)
        {
            Equipment[equipmentType] = equipment;
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
            sb.Append("Class: " + CharacterClass + "\n");
            sb.Append("Level: " + Level + "\n");
            sb.Append("Total Strength: " + Attributes.Strength + "\n");
            sb.Append("Total Dexterity: " + Attributes.Dexterity + "\n");
            sb.Append("Total Intelligence: " + Attributes.Intelligence + "\n");
            sb.Append("Damage: " + Damage() + "\n");
            foreach (var slot in Equipment)
            {
                Console.WriteLine("Slot: " + slot.Key + "\nName: " + slot.Value.Name + "\nDefense: " + slot.Value.Defense + "\n____________");
            }

            return sb.ToString();
        }



    }
}
