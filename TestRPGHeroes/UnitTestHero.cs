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





    }
}
