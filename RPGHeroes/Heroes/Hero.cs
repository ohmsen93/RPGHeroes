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
            if (equipment.LevelRequirement > Level)
            {
                throw new ArgumentException("The player's level is not high enough to equip this item.");
            }

            if (equipment is Weapon)
            {
                var weapon = (Weapon)equipment;
                if (!ValidWeaponTypes.Contains(weapon.BaseType))
                {
                    throw new ArgumentException("The player does not meet the requirements to equip this item.");
                }
            }
            else if (equipment is Armor)
            {
                var armor = (Armor)equipment;
                if (!ValidArmorTypes.Contains(armor.Type))
                {
                    throw new ArgumentException("The player does not meet the requirements to equip this item.");
                }
            }
            else
            {
                throw new ArgumentException("Invalid equipment type");
            }

            Equipment[equipmentType] = equipment;
        }


        public double Damage()
        {
            var totalAttributes = TotalAttributes();

            var weaponDamage = 0;

            if (Equipment.ContainsKey(EquipmentSlot.MainHand))
            {
                weaponDamage = Equipment[EquipmentSlot.MainHand].Attack;    
            }
            else
            {
                weaponDamage = 1;
            }

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
                    throw new ArgumentException("The Damaging Attribute for this class does not exist");
                    break;
            }



            var damage = (weaponDamage * (1 + (damagingAttribute / 100.0)));

            return (double)damage;
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
    
                sb.Append(
                    "\nSlot: " + slot.Key + 
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
