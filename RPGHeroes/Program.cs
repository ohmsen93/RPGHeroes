using RPGHeroes.Equipment;
using RPGHeroes.Heroes;

class Program
{
    static void Main(string[] args)
    {

        Mage mage = new Mage("Trogdorr");
        
        EquipmentFactory factory = new EquipmentFactory();
        Equipment staff = factory.CreateEquipment("Aether Staff", 20, 0, 1, "Weapon", "Staff");
        Equipment Cirlet = factory.CreateEquipment("Cirlet of missing enchantments", 0, 2, 1, "Armor", "Head", "Cloth");
        Equipment Robe = factory.CreateEquipment("Aether Robe", 0, 10, 1, "Armor", "Chest", "Cloth");
        Equipment Slippers = factory.CreateEquipment("Slippers of underwhelming potency", 0, 5, 1, "Armor", "Feet", "Cloth");

        mage.Equip(MageWeapons.Staff, staff);
        mage.Equip(MageArmor.Cloth, Cirlet);
        mage.Equip(MageArmor.Cloth, Robe);
        mage.Equip(MageArmor.Cloth, Slippers);





        Console.WriteLine("Status: ");
        Console.WriteLine(mage.Display());
   
    }
}