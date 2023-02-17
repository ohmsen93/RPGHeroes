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

        //LevelUp Method, attribute increases based of the attribute growth of the subClass Mage, Ranger, Rogue, Warrior
        public virtual void LevelUp()
        {
            Level++;
            Attributes.Strength += AttributeGrowth.StrengthGrowth;
            Attributes.Dexterity += AttributeGrowth.DexterityGrowth;
            Attributes.Intelligence += AttributeGrowth.IntelligenceGrowth;
        }

        // Equips equipment and throws the relevant exceptions when not meeting specified requirements.
        public void Equip(EquipmentSlot equipmentType, Equipment.Equipment equipment)
        {
            // We check if the hero meets the levelRequirements
            if (equipment.LevelRequirement > Level)
            {
                throw new ArgumentException("The player's level is not high enough to equip this item.");
            }

            // We check if the equipment is of the subclass Weapon or Armor
            if (equipment is Weapon)
            {
                // we check if the weapons baseType is available for the specific hero
                var weapon = (Weapon)equipment;
                if (!ValidWeaponTypes.Contains(weapon.BaseType))
                {
                    throw new ArgumentException("The player does not meet the requirements to equip this item.");
                }
            }
            else if (equipment is Armor)
            {
                // we check if the armor's ArmorType is available for the specific hero
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

            // if we hit none of the Exceptions we insert the equipment into our Equipment Dict
            Equipment[equipmentType] = equipment;
        }


        // Here we calculate the damage of the hero
        public double Damage()
        {
            var totalAttributes = TotalAttributes();

            var weaponDamage = 0;

            // We check if the hero has a weapon equipped, else we set the weaponDamage to 1
            if (Equipment.ContainsKey(EquipmentSlot.MainHand))
            {
                weaponDamage = Equipment[EquipmentSlot.MainHand].Attack;    
            }
            else
            {
                weaponDamage = 1;
            }

            var damagingAttribute = 0;

            // We check the subClass for the relevant damage Attribute, fx. in case of a mage, this attribute would be Intelligence
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


            //We calculate and return the damage
            var damage = (weaponDamage * (1 + (damagingAttribute / 100.0)));

            return damage;
        }


        // Here we calculate the total attributes of the hero on the fly.
        public Attributes TotalAttributes()
        {
            // we create a new attribute instance
            var returnAttr = new Attributes();

            // set our base stats to the new instance
            returnAttr.Strength = Attributes.Strength;
            returnAttr.Dexterity = Attributes.Dexterity;
            returnAttr.Intelligence = Attributes.Intelligence;

            // add attributes from the equipment, and return the attributes
                foreach (var slot in Equipment)
                {
                    returnAttr.Strength += slot.Value.EnchantmentAttributes.Strength;
                    returnAttr.Dexterity += slot.Value.EnchantmentAttributes.Dexterity;
                    returnAttr.Intelligence += slot.Value.EnchantmentAttributes.Intelligence;
                }

                return returnAttr;
        }


        // Here we utilize the StringBuilder to display the info on our hero.
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
