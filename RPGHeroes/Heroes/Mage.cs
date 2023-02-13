using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGHeroes.Equipment;

namespace RPGHeroes.Heroes
{



    public class Mage : Hero
    {
        public Mage(string name) : base(name)
        {
            ValidWeaponTypes = new List<WeaponBaseType>()
            {
                WeaponBaseType.Staff, WeaponBaseType.Wand
            };

            ValidArmorTypes = new List<ArmorType>()
            {
                ArmorType.Cloth
            };


            DamagingAttribute = "Intelligence";

            Attributes.Strength = 1;
            AttributeGrowth.StrengthGrowth = 1;

            Attributes.Dexterity = 1;
            AttributeGrowth.DexterityGrowth = 1;
            
            Attributes.Intelligence = 8;
            AttributeGrowth.IntelligenceGrowth = 5;



        }

        public override string CharacterClass => nameof(Mage);


    }
}
