using RPGHeroes.Equipment;
using RPGHeroes.Heroes;

namespace TestRPGHeroes
{
    public class UnitTestHero
    {
        /* Check Hero Creation */

        [Fact]
        public void CheckHeroCreationForCorrectVariables()
        {
            //Arrange
            Mage mage = new Mage("Merlin");
            var CheckName = "Merlin";
            var CheckLevel = 1;
            var CheckStrength = 1;
            var CheckDexterity = 1;
            var CheckIntelligence = 8;

            //Act


            //Assert
            Assert.Equal(CheckName, mage.Name);
            Assert.Equal(CheckLevel, mage.Level);
            Assert.Equal(CheckStrength, mage.Attributes.Strength);
            Assert.Equal(CheckDexterity, mage.Attributes.Dexterity);
            Assert.Equal(CheckIntelligence, mage.Attributes.Intelligence);
        }

        /* Check LevelUp and Attributes */

        [Fact]
        public void CheckLevelUpForCorrectIncrementMage()
        {
            Mage mage = new Mage("Casty");

            mage.LevelUp();

            Assert.Equal(2, mage.Level);
        }

        [Fact]
        public void CheckLevelUpForCorrectAttributeGrowthMage()
        {
            Mage mage = new Mage("Casty");

            mage.LevelUp();

            Assert.Equal(2, mage.Attributes.Strength);
            Assert.Equal(2, mage.Attributes.Dexterity);
            Assert.Equal(13, mage.Attributes.Intelligence);
        }

        [Fact]
        public void CheckLevelUpForCorrectIncrementRanger()
        {
            Ranger ranger = new Ranger("Pewey");

            ranger.LevelUp();

            Assert.Equal(2, ranger.Level);
        }

        [Fact]
        public void CheckLevelUpForCorrectAttributeGrowthRanger()
        {
            Ranger ranger = new Ranger("Pewey");

            ranger.LevelUp();

            Assert.Equal(2, ranger.Attributes.Strength);
            Assert.Equal(12, ranger.Attributes.Dexterity);
            Assert.Equal(2, ranger.Attributes.Intelligence);
        }

        [Fact]
        public void CheckLevelUpForCorrectIncrementRogue()
        {
            Rogue rogue = new Rogue("Stabby");

            rogue.LevelUp();

            Assert.Equal(2, rogue.Level);
        }

        [Fact]
        public void CheckLevelUpForCorrectAttributeGrowthRogue()
        {
            Rogue rogue = new Rogue("Stabby");

            rogue.LevelUp();

            Assert.Equal(3, rogue.Attributes.Strength);
            Assert.Equal(13, rogue.Attributes.Dexterity);
            Assert.Equal(2, rogue.Attributes.Intelligence);
        }

        [Fact]
        public void CheckLevelUpForCorrectIncrementWarrior()
        {
            Warrior warrior = new Warrior("Bashy");

            warrior.LevelUp();

            Assert.Equal(2, warrior.Level);
        }

        [Fact]
        public void CheckLevelUpForCorrectAttributeGrowthWarrior()
        {
            Warrior warrior = new Warrior("Bashy");

            warrior.LevelUp();

            Assert.Equal(10, warrior.Attributes.Strength);
            Assert.Equal(3, warrior.Attributes.Dexterity);
            Assert.Equal(2, warrior.Attributes.Intelligence);
        }

        [Fact]
        public void CheckEquipWeaponForRelevantExceptionOnMissingLevelRequirements()
        {
            
            Mage mage = new Mage("Merlin");

            EquipmentFactory factory = new ConcreteEquipmentFactory();

            Weapon staff = (Weapon)factory.CreateEquipment("Aether Staff", 32, 0, 10, "Weapon", "MainHand", intelligenceEnchantment: 12, weaponBaseType: "Staff");



            Assert.Throws<ArgumentException>(() => mage.Equip(EquipmentSlot.MainHand, staff));


        }

        [Fact]
        public void CheckEquipWeaponForRelevantExceptionOnMissingTypeRequirements()
        {
            Mage mage = new Mage("Merlin");

            EquipmentFactory factory = new ConcreteEquipmentFactory();

            Weapon staff = (Weapon)factory.CreateEquipment("Test Bow", 32, 0, 1, "Weapon", "MainHand", weaponBaseType: "Bow");

            Assert.Throws<ArgumentException>(() => mage.Equip(EquipmentSlot.MainHand, staff));
        }


        [Fact]
        public void CheckEquipArmorForRelevantExceptionOnMissingLevelRequirements()
        {
            Mage mage = new Mage("Merlin");

            EquipmentFactory factory = new ConcreteEquipmentFactory();

            Armor robe = (Armor)factory.CreateEquipment("Aether Robe", 0, 20, 10, "Armor", "Chest", strengthEnchantment: 2, dexterityEnchantment: 2, intelligenceEnchantment: 4, armorType: "Cloth");

            Assert.Throws<ArgumentException>(() => mage.Equip(EquipmentSlot.Chest, robe));

        }

        [Fact]
        public void CheckEquipArmorForRelevantExceptionOnMissingTypeRequirements()
        {
            Mage mage = new Mage("Merlin");

            EquipmentFactory factory = new ConcreteEquipmentFactory();

            Armor chest = (Armor)factory.CreateEquipment("Chest Plate", 0, 120, 1, "Armor", "Chest", armorType: "Plate");

            Assert.Throws<ArgumentException>(() => mage.Equip(EquipmentSlot.Chest, chest));


        }

        [Fact]
        public void CheckTotalAttributeCalculationNoEquipment()
        {
            Mage mage = new Mage("Merlin");

            var totalAttributes = mage.TotalAttributes();

            Assert.Equal(1, totalAttributes.Strength );
            Assert.Equal(1, totalAttributes.Dexterity );
            Assert.Equal(8, totalAttributes.Intelligence );
        }

        [Fact]
        public void CheckTotalAttributeCalculation1Equipment()
        {
            Mage mage = new Mage("Merlin");

            EquipmentFactory factory = new ConcreteEquipmentFactory();

            Armor robe = (Armor)factory.CreateEquipment("Aether Robe", 0, 20, 1, "Armor", "Chest", strengthEnchantment: 2, dexterityEnchantment: 2, intelligenceEnchantment: 4, armorType: "Cloth");

            mage.Equip(EquipmentSlot.Chest, robe);

            var totalAttributes = mage.TotalAttributes();

            Assert.Equal(3, totalAttributes.Strength);
            Assert.Equal(3, totalAttributes.Dexterity);
            Assert.Equal(12, totalAttributes.Intelligence);
        }

        [Fact]
        public void CheckTotalAttributeCalculation2Equipment()
        {
            Mage mage = new Mage("Merlin");

            EquipmentFactory factory = new ConcreteEquipmentFactory();

            Armor robe = (Armor)factory.CreateEquipment("Aether Robe", 0, 20, 1, "Armor", "Chest", strengthEnchantment: 2, dexterityEnchantment: 2, intelligenceEnchantment: 4, armorType: "Cloth");
            Armor feet = (Armor)factory.CreateEquipment("Aether Slippers", 0, 20, 1, "Armor", "Chest", strengthEnchantment: 0, dexterityEnchantment: 2, intelligenceEnchantment: 2, armorType: "Cloth");


            mage.Equip(EquipmentSlot.Chest, robe);
            mage.Equip(EquipmentSlot.Feet, feet);

            var totalAttributes = mage.TotalAttributes();

            Assert.Equal(3, totalAttributes.Strength);
            Assert.Equal(5, totalAttributes.Dexterity);
            Assert.Equal(14, totalAttributes.Intelligence);
        }

        [Fact]
        public void CheckTotalAttributeCalculationReplaceEquipment()
        {
            Mage mage = new Mage("Merlin");

            EquipmentFactory factory = new ConcreteEquipmentFactory();

            Armor robe = (Armor)factory.CreateEquipment("Aether Robe", 0, 20, 1, "Armor", "Chest", strengthEnchantment: 2, dexterityEnchantment: 2, intelligenceEnchantment: 4, armorType: "Cloth");
            Armor replacementRobe = (Armor)factory.CreateEquipment("Replacement Aether Robe", 0, 20, 1, "Armor", "Chest", strengthEnchantment: 2, dexterityEnchantment: 2, intelligenceEnchantment: 8, armorType: "Cloth");


            mage.Equip(EquipmentSlot.Chest, robe);
            mage.Equip(EquipmentSlot.Chest, replacementRobe);

            var totalAttributes = mage.TotalAttributes();

            Assert.Equal(3, totalAttributes.Strength);
            Assert.Equal(3, totalAttributes.Dexterity);
            Assert.Equal(16, totalAttributes.Intelligence);
        }

        
        [Fact]
        public void CheckDamageCalculationNoWeapon()
        {
            Mage mage = new Mage("Merlin");

          

            Assert.Equal(1.08, Math.Round(mage.Damage(), 2));

        }

        [Fact]
        public void CheckDamageCalculationWeaponEquipped()
        {
            Mage mage = new Mage("Merlin");

            EquipmentFactory factory = new ConcreteEquipmentFactory();

            Weapon staff = (Weapon)factory.CreateEquipment("Aether Staff", 32, 0, 1, "Weapon", "MainHand", intelligenceEnchantment: 12, weaponBaseType: "Staff");

            mage.Equip(EquipmentSlot.MainHand, staff);


            Assert.Equal(38.4, Math.Round(mage.Damage(), 2));
     
        }

        [Fact]
        public void CheckDamageCalculationWeaponReplaced()
        {
            Mage mage = new Mage("Merlin");

            EquipmentFactory factory = new ConcreteEquipmentFactory();

            Weapon staff = (Weapon)factory.CreateEquipment("Aether Staff", 32, 0, 1, "Weapon", "MainHand", intelligenceEnchantment: 12, weaponBaseType: "Staff");
            Weapon wand = (Weapon)factory.CreateEquipment("Aether wand", 22, 0, 1, "Weapon", "MainHand", intelligenceEnchantment: 10, weaponBaseType: "Wand");



            mage.Equip(EquipmentSlot.MainHand, staff);
            mage.Equip(EquipmentSlot.MainHand, wand);



            Assert.Equal(25.96, Math.Round(mage.Damage(), 2));
        }

        [Fact]
        public void CheckDamageCalculationWeaponAndEquipment()
        {
            Mage mage = new Mage("Merlin");

            EquipmentFactory factory = new ConcreteEquipmentFactory();

            Weapon staff = (Weapon)factory.CreateEquipment("Aether Staff", 32, 0, 1, "Weapon", "MainHand", intelligenceEnchantment: 12, weaponBaseType: "Staff");
            Armor robe = (Armor)factory.CreateEquipment("Aether Robe", 0, 20, 1, "Armor", "Chest", strengthEnchantment: 2, dexterityEnchantment: 2, intelligenceEnchantment: 4, armorType: "Cloth");
            Armor circlet = (Armor)factory.CreateEquipment("Aether circlet", 0, 2, 1, "Armor", "Head", strengthEnchantment: 2, dexterityEnchantment: 2, intelligenceEnchantment: 8, armorType: "Cloth");
            Armor feet = (Armor)factory.CreateEquipment("Aether slippers", 0, 12, 1, "Armor", "Feet", strengthEnchantment: 2, dexterityEnchantment: 2, intelligenceEnchantment: 5, armorType: "Cloth");


            mage.Equip(EquipmentSlot.Chest, robe);
            mage.Equip(EquipmentSlot.Head, circlet);
            mage.Equip(EquipmentSlot.Feet, feet);
            mage.Equip(EquipmentSlot.MainHand, staff);


            Assert.Equal(43.84, Math.Round(mage.Damage(), 2));
        }

        [Fact]
        public void CheckDisplayForCorrectValues()
        {
            Mage mage = new Mage("Merlin");

            EquipmentFactory factory = new ConcreteEquipmentFactory();

            Weapon staff = (Weapon)factory.CreateEquipment("Aether Staff", 32, 0, 1, "Weapon", "MainHand", intelligenceEnchantment: 12, weaponBaseType: "Staff");
            Armor robe = (Armor)factory.CreateEquipment("Aether Robe", 0, 20, 1, "Armor", "Chest", strengthEnchantment: 2, dexterityEnchantment: 2, intelligenceEnchantment: 4, armorType: "Cloth");
            Armor circlet = (Armor)factory.CreateEquipment("Aether circlet", 0, 2, 1, "Armor", "Head", strengthEnchantment: 2, dexterityEnchantment: 2, intelligenceEnchantment: 8, armorType: "Cloth");
            Armor feet = (Armor)factory.CreateEquipment("Aether slippers", 0, 12, 1, "Armor", "Feet", strengthEnchantment: 2, dexterityEnchantment: 2, intelligenceEnchantment: 5, armorType: "Cloth");


            mage.Equip(EquipmentSlot.MainHand, staff);
            mage.Equip(EquipmentSlot.Head, circlet);
            mage.Equip(EquipmentSlot.Chest, robe);
            mage.Equip(EquipmentSlot.Feet, feet);


            var expectedDisplay = "Name: Merlin\nClass: Mage\nLevel: 1\nTotal Strength: 7(+6)\nTotal Dexterity: 7(+6)\nTotal Intelligence: 37(+29)\nDamage: 43,84\n\nSlot: MainHand\nName: Aether Staff\nDefense: 0\nEnchantments - \nStrength: 0\nDexterity: 0\nIntelligence: 12\n____________\nSlot: Head\nName: Aether circlet\nDefense: 2\nEnchantments - \nStrength: 2\nDexterity: 2\nIntelligence: 8\n____________\nSlot: Chest\nName: Aether Robe\nDefense: 20\nEnchantments - \nStrength: 2\nDexterity: 2\nIntelligence: 4\n____________\nSlot: Feet\nName: Aether slippers\nDefense: 12\nEnchantments - \nStrength: 2\nDexterity: 2\nIntelligence: 5\n____________";
                Assert.Equal(expectedDisplay, mage.Display());
        }

    }
}
