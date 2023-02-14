using RPGHeroes.Equipment;
using RPGHeroes.Heroes;
using static System.Net.Mime.MediaTypeNames;

namespace TestRPGHeroes;

public class UnitTestEquipment
{

    /* Weapon Test */

    [Fact]
    public void CheckWeaponCreationForCorrectVariables()
    {
        //Arrange
        EquipmentFactory factory = new ConcreteEquipmentFactory();

        var name = "Aether Staff";
        var attack = 32;
        var defence = 0;
        var levelRequirement = 1;
        var strengthEnchantment = 0;
        var dexterityEnchantment = 0;
        var intelligenceEnchantment = 12;
        var weaponBaseType = "Staff";


        //Act
        Weapon staff = (Weapon)factory.CreateEquipment("Aether Staff", 32, 0, 1, "Weapon", "MainHand", intelligenceEnchantment: 12, weaponBaseType: "Staff");

  

        //Assert
        Assert.Equal(name, staff.Name );
        Assert.Equal(attack, staff.Attack);
        Assert.Equal(defence, staff.Defense);
        Assert.Equal(levelRequirement, staff.LevelRequirement);
        Assert.Equal(EquipmentSlot.MainHand, staff.Slot);
        Assert.Equal(WeaponBaseType.Staff, staff.BaseType);
        Assert.Equal(strengthEnchantment, staff.EnchantmentAttributes.Strength );
        Assert.Equal(dexterityEnchantment, staff.EnchantmentAttributes.Dexterity );
        Assert.Equal(intelligenceEnchantment, staff.EnchantmentAttributes.Intelligence );
    }

    /* Armor Test */

    [Fact]
    public void CheckArmorCreationForCorrectVariables()
    {
        //Arrange
        EquipmentFactory factory = new ConcreteEquipmentFactory();

        var name = "Aether Robe";
        var attack = 0;
        var defence = 20;
        var levelRequirement = 1;
        var strengthEnchantment = 2;
        var dexterityEnchantment = 2;
        var intelligenceEnchantment = 4;


        //Act
        Armor robe = (Armor)factory.CreateEquipment("Aether Robe", 0, 20, 1, "Armor", "Chest", strengthEnchantment: 2, dexterityEnchantment: 2, intelligenceEnchantment: 4, armorType: "Cloth");



        //Assert
        Assert.Equal(name, robe.Name);
        Assert.Equal(attack, robe.Attack);
        Assert.Equal(defence, robe.Defense);
        Assert.Equal(levelRequirement, robe.LevelRequirement);
        Assert.Equal(EquipmentSlot.Chest, robe.Slot);
        Assert.Equal(ArmorType.Cloth, robe.Type);
        Assert.Equal(strengthEnchantment, robe.EnchantmentAttributes.Strength);
        Assert.Equal(dexterityEnchantment, robe.EnchantmentAttributes.Dexterity);
        Assert.Equal(intelligenceEnchantment, robe.EnchantmentAttributes.Intelligence);
    }

}