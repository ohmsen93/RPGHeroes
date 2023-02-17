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
            // Arrange
            var expectedName = "Merlin";
            var expectedLevel = 1;
            var expectedStrength = 1;
            var expectedDexterity = 1;
            var expectedIntelligence = 8;

            // Act
            var mage = new Mage(expectedName);

            // Assert
            Assert.Equal(expectedName, mage.Name);
            Assert.Equal(expectedLevel, mage.Level);
            Assert.Equal(expectedStrength, mage.Attributes.Strength);
            Assert.Equal(expectedDexterity, mage.Attributes.Dexterity);
            Assert.Equal(expectedIntelligence, mage.Attributes.Intelligence);
        }

        /* Check LevelUp and Attributes */

        [Fact]
        public void CheckLevelUpForCorrectIncrementMage()
        {
            // Arrange
            var mage = new Mage("Casty");

            // Act
            mage.LevelUp();

            // Assert
            Assert.Equal(2, mage.Level);
        }

        [Fact]
        public void CheckLevelUpForCorrectAttributeGrowthMage()
        {
            // Arrange
            var mage = new Mage("Casty");

            // Act
            mage.LevelUp();

            // Assert
            Assert.Equal(2, mage.Attributes.Strength);
            Assert.Equal(2, mage.Attributes.Dexterity);
            Assert.Equal(13, mage.Attributes.Intelligence);
        }

        [Fact]
        public void CheckLevelUpForCorrectIncrementRanger()
        {
            // Arrange
            var ranger = new Ranger("Pewey");

            // Act
            ranger.LevelUp();

            // Assert
            Assert.Equal(2, ranger.Level);
        }

        [Fact]
        public void CheckLevelUpForCorrectAttributeGrowthRanger()
        {
            // Arrange
            var ranger = new Ranger("Pewey");

            // Act
            ranger.LevelUp();

            // Assert
            Assert.Equal(2, ranger.Attributes.Strength);
            Assert.Equal(12, ranger.Attributes.Dexterity);
            Assert.Equal(2, ranger.Attributes.Intelligence);
        }

        [Fact]
        public void CheckLevelUpForCorrectIncrementRogue()
        {
            // Arrange
            var rogue = new Rogue("Stabby");

            // Act
            rogue.LevelUp();

            // Assert
            Assert.Equal(2, rogue.Level);
        }

        [Fact]
        public void CheckLevelUpForCorrectAttributeGrowthRogue()
        {
            // Arrange
            var rogue = new Rogue("Stabby");

            // Act
            rogue.LevelUp();

            // Assert
            Assert.Equal(3, rogue.Attributes.Strength);
            Assert.Equal(13, rogue.Attributes.Dexterity);
            Assert.Equal(2, rogue.Attributes.Intelligence);
        }

        [Fact]
        public void CheckLevelUpForCorrectIncrementWarrior()
        {
            // Arrange
            var warrior = new Warrior("Bashy");

            // Act
            warrior.LevelUp();

            // Assert
            Assert.Equal(2, warrior.Level);
        }

        [Fact]
        public void CheckLevelUpForCorrectAttributeGrowthWarrior()
        {
            // Arrange
            var warrior = new Warrior("Bashy");

            // Act
            warrior.LevelUp();

            // Assert
            Assert.Equal(10, warrior.Attributes.Strength);
            Assert.Equal(3, warrior.Attributes.Dexterity);
            Assert.Equal(2, warrior.Attributes.Intelligence);
        }

        [Fact]
        public void CheckEquipWeaponForRelevantExceptionOnMissingLevelRequirements()
        {
            // Arrange
            Mage mage = new Mage("Merlin");
            EquipmentFactory factory = new ConcreteEquipmentFactory();
            Weapon staff = (Weapon)factory.CreateEquipment("Aether Staff", 32, 0, 10, "Weapon", "MainHand", intelligenceEnchantment: 12, weaponBaseType: "Staff");


            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => mage.Equip(EquipmentSlot.MainHand, staff));
            Assert.Equal("The player's level is not high enough to equip this item.", ex.Message);

        }

        [Fact]
        public void CheckEquipWeaponForRelevantExceptionOnMissingTypeRequirements()
        {
            // Arrange
            Mage mage = new Mage("Merlin");
            EquipmentFactory factory = new ConcreteEquipmentFactory();
            Weapon staff = (Weapon)factory.CreateEquipment("Test Bow", 32, 0, 1, "Weapon", "MainHand", weaponBaseType: "Bow");

            //Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => mage.Equip(EquipmentSlot.MainHand, staff));
            Assert.Equal("The player does not meet the requirements to equip this item.", ex.Message);
        }


        [Fact]
        public void CheckEquipArmorForRelevantExceptionOnMissingLevelRequirements()
        {
            // Arrange
            Mage mage = new Mage("Merlin");
            EquipmentFactory factory = new ConcreteEquipmentFactory();
            Armor robe = (Armor)factory.CreateEquipment("Aether Robe", 0, 20, 10, "Armor", "Chest", strengthEnchantment: 2, dexterityEnchantment: 2, intelligenceEnchantment: 4, armorType: "Cloth");

            //Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => mage.Equip(EquipmentSlot.Chest, robe));
            Assert.Equal("The player's level is not high enough to equip this item.", ex.Message);

        }

        [Fact]
        public void CheckEquipArmorForRelevantExceptionOnMissingTypeRequirements()
        {
            //Arrange
            Mage mage = new Mage("Merlin");
            EquipmentFactory factory = new ConcreteEquipmentFactory();
            Armor chest = (Armor)factory.CreateEquipment("Chest Plate", 0, 120, 1, "Armor", "Chest", armorType: "Plate");

            //Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => mage.Equip(EquipmentSlot.Chest, chest));
            Assert.Equal("The player does not meet the requirements to equip this item.", ex.Message);


        }

        [Fact]
        public void CheckTotalAttributeCalculationNoEquipment()
        {
            //Arrange
            Mage mage = new Mage("Merlin");

            //Act
            var totalAttributes = mage.TotalAttributes();

            //Assert
            Assert.Equal(1, totalAttributes.Strength );
            Assert.Equal(1, totalAttributes.Dexterity );
            Assert.Equal(8, totalAttributes.Intelligence );
        }

        [Fact]
        public void CheckTotalAttributeCalculation1Equipment()
        {
            //Arrange
            Mage mage = new Mage("Merlin");
            EquipmentFactory factory = new ConcreteEquipmentFactory();
            Armor robe = (Armor)factory.CreateEquipment("Aether Robe", 0, 20, 1, "Armor", "Chest", strengthEnchantment: 2, dexterityEnchantment: 2, intelligenceEnchantment: 4, armorType: "Cloth");

            //Act
            mage.Equip(EquipmentSlot.Chest, robe);
            var totalAttributes = mage.TotalAttributes();

            //Assert
            Assert.Equal(3, totalAttributes.Strength);
            Assert.Equal(3, totalAttributes.Dexterity);
            Assert.Equal(12, totalAttributes.Intelligence);
        }

        [Fact]
        public void CheckTotalAttributeCalculation2Equipment()
        {
            //Arrange
            Mage mage = new Mage("Merlin");
            EquipmentFactory factory = new ConcreteEquipmentFactory();
            Armor robe = (Armor)factory.CreateEquipment("Aether Robe", 0, 20, 1, "Armor", "Chest", strengthEnchantment: 2, dexterityEnchantment: 2, intelligenceEnchantment: 4, armorType: "Cloth");
            Armor feet = (Armor)factory.CreateEquipment("Aether Slippers", 0, 20, 1, "Armor", "Chest", strengthEnchantment: 0, dexterityEnchantment: 2, intelligenceEnchantment: 2, armorType: "Cloth");

            //Act
            mage.Equip(EquipmentSlot.Chest, robe);
            mage.Equip(EquipmentSlot.Feet, feet);
            var totalAttributes = mage.TotalAttributes();

            //Assert
            Assert.Equal(3, totalAttributes.Strength);
            Assert.Equal(5, totalAttributes.Dexterity);
            Assert.Equal(14, totalAttributes.Intelligence);
        }

        [Fact]
        public void CheckTotalAttributeCalculationReplaceEquipment()
        {
            //Arrange
            Mage mage = new Mage("Merlin");
            EquipmentFactory factory = new ConcreteEquipmentFactory();
            Armor robe = (Armor)factory.CreateEquipment("Aether Robe", 0, 20, 1, "Armor", "Chest", strengthEnchantment: 2, dexterityEnchantment: 2, intelligenceEnchantment: 4, armorType: "Cloth");
            Armor replacementRobe = (Armor)factory.CreateEquipment("Replacement Aether Robe", 0, 20, 1, "Armor", "Chest", strengthEnchantment: 2, dexterityEnchantment: 2, intelligenceEnchantment: 8, armorType: "Cloth");

            //Act
            mage.Equip(EquipmentSlot.Chest, robe);
            mage.Equip(EquipmentSlot.Chest, replacementRobe);
            var totalAttributes = mage.TotalAttributes();

            //Assert
            Assert.Equal(3, totalAttributes.Strength);
            Assert.Equal(3, totalAttributes.Dexterity);
            Assert.Equal(16, totalAttributes.Intelligence);
        }

        
        [Fact]
        public void CheckDamageCalculationNoWeapon()
        {
            //Arrange
            Mage mage = new Mage("Merlin");

          
            //Act & Assert
            Assert.Equal(1.08, Math.Round(mage.Damage(), 2));

        }

        [Fact]
        public void CheckDamageCalculationWeaponEquipped()
        {
            //Arrange
            Mage mage = new Mage("Merlin");
            EquipmentFactory factory = new ConcreteEquipmentFactory();
            Weapon staff = (Weapon)factory.CreateEquipment("Aether Staff", 32, 0, 1, "Weapon", "MainHand", intelligenceEnchantment: 12, weaponBaseType: "Staff");

            //Act
            mage.Equip(EquipmentSlot.MainHand, staff);

            //Assert
            Assert.Equal(38.4, Math.Round(mage.Damage(), 2));
        }

        [Fact]
        public void CheckDamageCalculationWeaponReplaced()
        {
            //Arrange
            Mage mage = new Mage("Merlin");
            EquipmentFactory factory = new ConcreteEquipmentFactory();
            Weapon staff = (Weapon)factory.CreateEquipment("Aether Staff", 32, 0, 1, "Weapon", "MainHand", intelligenceEnchantment: 12, weaponBaseType: "Staff");
            Weapon wand = (Weapon)factory.CreateEquipment("Aether wand", 22, 0, 1, "Weapon", "MainHand", intelligenceEnchantment: 10, weaponBaseType: "Wand");

            //Act
            mage.Equip(EquipmentSlot.MainHand, staff);
            mage.Equip(EquipmentSlot.MainHand, wand);

            //Assert
            Assert.Equal(25.96, Math.Round(mage.Damage(), 2));
        }

        [Fact]
        public void CheckDamageCalculationWeaponAndEquipment()
        {
            //Arrange
            Mage mage = new Mage("Merlin");
            EquipmentFactory factory = new ConcreteEquipmentFactory();
            Weapon staff = (Weapon)factory.CreateEquipment("Aether Staff", 32, 0, 1, "Weapon", "MainHand", intelligenceEnchantment: 12, weaponBaseType: "Staff");
            Armor robe = (Armor)factory.CreateEquipment("Aether Robe", 0, 20, 1, "Armor", "Chest", strengthEnchantment: 2, dexterityEnchantment: 2, intelligenceEnchantment: 4, armorType: "Cloth");
            Armor circlet = (Armor)factory.CreateEquipment("Aether circlet", 0, 2, 1, "Armor", "Head", strengthEnchantment: 2, dexterityEnchantment: 2, intelligenceEnchantment: 8, armorType: "Cloth");
            Armor feet = (Armor)factory.CreateEquipment("Aether slippers", 0, 12, 1, "Armor", "Feet", strengthEnchantment: 2, dexterityEnchantment: 2, intelligenceEnchantment: 5, armorType: "Cloth");

            //Act
            mage.Equip(EquipmentSlot.Chest, robe);
            mage.Equip(EquipmentSlot.Head, circlet);
            mage.Equip(EquipmentSlot.Feet, feet);
            mage.Equip(EquipmentSlot.MainHand, staff);

            //Assert
            Assert.Equal(43.84, Math.Round(mage.Damage(), 2));
        }

        [Fact]
        public void CheckDisplayForCorrectValues()
        {
            //Arrange
            Mage mage = new Mage("Merlin");
            EquipmentFactory factory = new ConcreteEquipmentFactory();
            Weapon staff = (Weapon)factory.CreateEquipment("Aether Staff", 32, 0, 1, "Weapon", "MainHand", intelligenceEnchantment: 12, weaponBaseType: "Staff");
            Armor robe = (Armor)factory.CreateEquipment("Aether Robe", 0, 20, 1, "Armor", "Chest", strengthEnchantment: 2, dexterityEnchantment: 2, intelligenceEnchantment: 4, armorType: "Cloth");
            Armor circlet = (Armor)factory.CreateEquipment("Aether circlet", 0, 2, 1, "Armor", "Head", strengthEnchantment: 2, dexterityEnchantment: 2, intelligenceEnchantment: 8, armorType: "Cloth");
            Armor feet = (Armor)factory.CreateEquipment("Aether slippers", 0, 12, 1, "Armor", "Feet", strengthEnchantment: 2, dexterityEnchantment: 2, intelligenceEnchantment: 5, armorType: "Cloth");

            //Act
            mage.Equip(EquipmentSlot.MainHand, staff);
            mage.Equip(EquipmentSlot.Head, circlet);
            mage.Equip(EquipmentSlot.Chest, robe);
            mage.Equip(EquipmentSlot.Feet, feet);

            //Assert
            var expectedDisplay = "Name: Merlin\nClass: Mage\nLevel: 1\nTotal Strength: 7(+6)\nTotal Dexterity: 7(+6)\nTotal Intelligence: 37(+29)\nDamage: 43.84\n\nSlot: MainHand\nName: Aether Staff\nDefense: 0\nEnchantments - \nStrength: 0\nDexterity: 0\nIntelligence: 12\n____________\nSlot: Head\nName: Aether circlet\nDefense: 2\nEnchantments - \nStrength: 2\nDexterity: 2\nIntelligence: 8\n____________\nSlot: Chest\nName: Aether Robe\nDefense: 20\nEnchantments - \nStrength: 2\nDexterity: 2\nIntelligence: 4\n____________\nSlot: Feet\nName: Aether slippers\nDefense: 12\nEnchantments - \nStrength: 2\nDexterity: 2\nIntelligence: 5\n____________";
                Assert.Equal(expectedDisplay, mage.Display());
        }

    }
}
