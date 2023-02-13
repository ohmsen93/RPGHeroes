using RPGHeroes.Equipment;
using RPGHeroes.Heroes;

class Program
{
    static void Main(string[] args)
    {

        Mage mage = new Mage("Trogdorr");

        EquipmentFactory factory = new ConcreteEquipmentFactory();

        Equipment Staff = factory.CreateEquipment("Aether Staff", 32, 0, 1, "Weapon", "MainHand", "Staff");
        Equipment Circlet = factory.CreateEquipment("Aether Circlet", 0, 2, 1, "Armor", "Head", null, "Cloth");
        Equipment Robe = factory.CreateEquipment("Aether Robes", 0, 32, 1, "Armor", "Chest", null, "Cloth");
        Equipment Slippers = factory.CreateEquipment("Aether Slippers", 0, 12, 1, "Armor", "Feet", null, "Cloth");



        mage.Equip(EquipmentSlot.MainHand, Staff);
        mage.Equip(EquipmentSlot.Head, Circlet);
        mage.Equip(EquipmentSlot.Chest, Robe);
        mage.Equip(EquipmentSlot.Feet, Slippers);

        mage.LevelUp();
        mage.LevelUp();
        mage.LevelUp();



        Console.WriteLine("Status: ");
        Console.WriteLine(mage.Display());
   
    }
}