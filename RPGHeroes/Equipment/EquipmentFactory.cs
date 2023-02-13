using RPGHeroes.Equipment;

public abstract class EquipmentFactory
{
    protected readonly Dictionary<string, WeaponBaseType> WeaponBaseTypes = new Dictionary<string, WeaponBaseType>
    {
        { "Axe", WeaponBaseType.Axe },
        { "Bow", WeaponBaseType.Bow },
        { "Dagger", WeaponBaseType.Dagger },
        { "Hammer", WeaponBaseType.Hammer },
        { "Staff", WeaponBaseType.Staff },
        { "Sword", WeaponBaseType.Sword },
        { "Wand", WeaponBaseType.Wand }
    };

    protected readonly Dictionary<string, ArmorType> ArmorTypes = new Dictionary<string, ArmorType>
    {
        { "Cloth", ArmorType.Cloth },
        { "Leather", ArmorType.Leather },
        { "Mail", ArmorType.Mail },
        { "Plate", ArmorType.Plate}

    };

    protected readonly Dictionary<string, EquipmentSlot> EquipmentSlots = new Dictionary<string, EquipmentSlot>
    {
        { "Head", EquipmentSlot.Head },
        { "Chest", EquipmentSlot.Chest },
        { "Wrist", EquipmentSlot.Wrist },
        { "Hands", EquipmentSlot.Hands },
        { "Waist", EquipmentSlot.Waist },
        { "Legs", EquipmentSlot.Legs },
        { "Feet", EquipmentSlot.Feet },
        { "MainHand", EquipmentSlot.MainHand },
        { "Offhand", EquipmentSlot.OffHand }
    };

    public abstract Equipment CreateEquipment(string name, int attack, int defense, int levelRequirement, string type, string subType, string weaponBaseType = null, string armorType = null);
}
