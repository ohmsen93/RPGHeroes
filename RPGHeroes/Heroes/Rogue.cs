using RPGHeroes.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes
{


    public class Rogue : Hero
    {
        public Rogue(string name) : base(name)
        {
            ValidWeaponTypes = new List<WeaponBaseType>()
            {
                WeaponBaseType.Dagger, WeaponBaseType.Sword
            };

            ValidArmorTypes = new List<ArmorType>()
            {
                ArmorType.Leather, ArmorType.Mail
            };

            DamagingAttribute = "Dexterity";


            Attributes.Strength = 2;
            AttributeGrowth.StrengthGrowth = 1;

            Attributes.Dexterity = 8;
            AttributeGrowth.DexterityGrowth = 5;

            Attributes.Intelligence = 1;
            AttributeGrowth.IntelligenceGrowth = 1;

        }

        public override string CharacterClass => nameof(Rogue);


    }
}
