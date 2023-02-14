using RPGHeroes.Equipment;
using RPGHeroes.Heroes;
using static System.Net.Mime.MediaTypeNames;

namespace TestRPGHeroes;

public class UnitTestEquipment
{
    [Fact]
    public void CheckWeaponCreationForCorrectVariables()
    {
        //Arrange
        Mage mage = new Mage("Merlin");
        EquipmentFactory factory = new ConcreteEquipmentFactory();

        var name = "Aether Staff";
        var attack = 32;
        var defence = 0;
        var levelRequirement = 1;
        var subType = "MainHand";
        var strengthEnchantment = 0;
        var dexterityEnchantment = 0;
        var intelligenceEnchantment = 12;
        var weaponBaseType = "Staff";


        //Act
        Equipment Staff = factory.CreateEquipment("Aether Staff", 32, 0, 1, "Weapon", "MainHand", intelligenceEnchantment: 12, weaponBaseType: "Staff");

        mage.Equip(EquipmentSlot.MainHand, Staff);


        //Assert
        Assert.Equal(name, mage.Equipment[]);
        Assert.Equal(attack, Staff.Attack);
        Assert.Equal(defence, Staff.Defense);
        Assert.Equal(levelRequirement, Staff.LevelRequirement);
        Assert.Equal(subType, );
  
    }
}