using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public Attributes Attributes { get; set; }


        public string DamagingAttribute { get; set; }

        public AttributeGrowth AttributeGrowth { get; set; }
        public List<WeaponBaseType> ValidWeaponTypes { get; set; }
        public List<ArmorType> ValidArmorTypes { get; set; }
        public Dictionary<EquipmentSlot, Equipment.Equipment> Equipment { get; set; }


        public Hero(string name)
        {
            Name = name;
            Level = 1;
            Equipment = new Dictionary<EquipmentSlot, Equipment.Equipment>();
            Attributes = new Attributes();
            AttributeGrowth = new AttributeGrowth();
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
            var totalAttributes = TotalAttributes(); 

            var weaponDamage = Equipment[EquipmentSlot.MainHand].Attack;
            var damagingAttribute = 0;

            switch (DamagingAttribute)
            {
                case "Strength":
                    damagingAttribute = totalAttributes.Strength;
                    break;
                case "Dexterity":
                    damagingAttribute = totalAttributes.Dexterity;
                    break;
                case "Intelligence":
                    damagingAttribute = totalAttributes.Intelligence;
                    break;
                default:
                    break;
            }

            var damage = weaponDamage * (1 + damagingAttribute / 100);
            return damage;
        }

        public Attributes TotalAttributes()
        {

            var returnAttr = new Attributes();

            returnAttr.Strength = Attributes.Strength;
            returnAttr.Dexterity = Attributes.Dexterity;
            returnAttr.Intelligence = Attributes.Intelligence;


                foreach (var slot in Equipment)
                {
                    returnAttr.Strength += slot.Value.EnchantmentAttributes.Strength;
                    returnAttr.Dexterity += slot.Value.EnchantmentAttributes.Dexterity;
                    returnAttr.Intelligence += slot.Value.EnchantmentAttributes.Intelligence;
                }

                return returnAttr;
        }



        public string Display()
        {
            var totalAttributes = TotalAttributes();
            StringBuilder sb = new StringBuilder();
            sb.Append("Name: " + Name + "\n");
            sb.Append("Class: " + CharacterClass + "\n");
            sb.Append("Level: " + Level + "\n");
            sb.Append("Total Strength: " + totalAttributes.Strength + "(+"+ (totalAttributes.Strength -Attributes.Strength) +")" + "\n");
            sb.Append("Total Dexterity: " + totalAttributes.Dexterity + "(+" + (totalAttributes.Dexterity - Attributes.Dexterity) + ")" + "\n");
            sb.Append("Total Intelligence: " + totalAttributes.Intelligence + "(+" + (totalAttributes.Intelligence -Attributes.Intelligence) + ")" + "\n");
            sb.Append("Damage: " + Damage() + "\n");
            foreach (var slot in Equipment)
            {
    
                Console.WriteLine(
                    "Slot: " + slot.Key + 
                    "\nName: " + slot.Value.Name + 
                    "\nDefense: " + slot.Value.Defense + 
                    "\nEnchantments - " + 
                    "\nStrength: " + slot.Value.EnchantmentAttributes.Strength + 
                    "\nDexterity: " + slot.Value.EnchantmentAttributes.Dexterity + 
                    "\nIntelligence: " + slot.Value.EnchantmentAttributes.Intelligence + 
                    "\n____________");
            }

            return sb.ToString();
        }



    }
}
