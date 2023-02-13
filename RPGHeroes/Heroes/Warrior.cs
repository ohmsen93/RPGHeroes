using RPGHeroes.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes
{



    public class Warrior : Hero
    {
        public Warrior(string name) : base(name)
        {
            ValidWeaponTypes = new List<WeaponBaseType>()
            {
                WeaponBaseType.Axe, WeaponBaseType.Hammer, WeaponBaseType.Sword
            };

            ValidArmorTypes = new List<ArmorType>()
            {
                ArmorType.Mail, ArmorType.Plate
            };

            DamagingAttribute = "Strength";


            Attributes.Strength = 5;
            AttributeGrowth.StrengthGrowth = 5;

            Attributes.Dexterity = 2;
            AttributeGrowth.DexterityGrowth = 1;

            Attributes.Intelligence = 1;
            AttributeGrowth.IntelligenceGrowth = 1;

        }

        public override string CharacterClass => nameof(Warrior);

    }
}
