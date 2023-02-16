using RPGHeroes.Equipment;
using RPGHeroes.Heroes;

class Program
{
    static void Main(string[] args)
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



        Console.WriteLine(mage.Display());
   
    }
}