namespace RPGHeroes.Equipment;

public class ConcreteEquipmentFactory : EquipmentFactory
{
    public override Equipment CreateEquipment(string name, int attack, int defense, int levelRequirement, string type, string subType, string weaponBaseType = null, string armorType = null)
    {
        if (type == "Weapon")
        {
            return new Weapon(name, attack, levelRequirement, base.EquipmentSlots[subType], base.WeaponBaseTypes[weaponBaseType]);
        }
        else if (type == "Armor")
        {
            return new Armor(name, defense, levelRequirement, base.EquipmentSlots[subType], base.ArmorTypes[armorType]);
        }
        else
        {
            return null;
        }
    }
}
