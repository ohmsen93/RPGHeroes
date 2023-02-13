using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGHeroes.Equipment;

namespace RPGHeroes.Heroes
{

    public class Ranger : Hero
    {
        public Ranger(string name) : base(name)
        {
            ValidWeaponTypes = new List<WeaponBaseType>()
            {
                WeaponBaseType.Bow
            };

            ValidArmorTypes = new List<ArmorType>()
            {
                ArmorType.Leather, ArmorType.Mail
            };

            DamagingAttribute = "Dexterity";


            Attributes.Strength = 1;
            AttributeGrowth.StrengthGrowth = 1;

            Attributes.Dexterity = 7;
            AttributeGrowth.DexterityGrowth = 5;

            Attributes.Intelligence = 1;
            AttributeGrowth.IntelligenceGrowth = 1;


        }

        public override string CharacterClass => nameof(Ranger);


    }
}
