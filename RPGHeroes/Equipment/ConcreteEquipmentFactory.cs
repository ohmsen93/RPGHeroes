namespace RPGHeroes.Equipment;

public class ConcreteEquipmentFactory : EquipmentFactory
{
    public override Equipment CreateEquipment(string name, int attack, int defense, int levelRequirement, string type,
        string subType,
        int strengthEnchantment, int dexterityEnchantment, int intelligenceEnchantment, string weaponBaseType = null,
        string armorType = null)
    {
        if (type == "Weapon")
        {
            return new Weapon(name, attack, levelRequirement, base.EquipmentSlots[subType],
                base.WeaponBaseTypes[weaponBaseType], strengthEnchantment, dexterityEnchantment,
                intelligenceEnchantment);
        }
        else if (type == "Armor")
        {
            return new Armor(name, defense, levelRequirement, base.EquipmentSlots[subType], base.ArmorTypes[armorType],
                strengthEnchantment, dexterityEnchantment, intelligenceEnchantment);
        }
        else
        {
            return null;
        }
    }
}

