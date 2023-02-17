# RPGHeroes

This is a project which introduces us to the basic mechanics and functions of Visual studio and c#.

It is a console project, but the primary objective is to create a structure for an RPG game which we can test.

Here is a class diagram of the project

![image](https://user-images.githubusercontent.com/6428939/219625896-0427735e-cf32-49c9-b294-eef60457d2ea.png)

And these are the things being tested

•When a Hero is created, it needs to have the correct name, level, and attributes.
• When a Heroes level is increased, it needs to increment by the correct amount and result in the correct
attributes.
  o Creation and leveling tests need to be written for each sub class
  o A test to see if HeroAttribute is being added/increased correctly should also be written
• When Weapon is created, it needs to have the correct name, required level, slot, weapon type, and damage
• When Armor is created, it needs to have the correct name, required level, slot, armor type, and armor attributes
• A Hero should be able to equip a Weapon, the appropriate exceptions should be thrown if invalid (level
requirement and type)
• A Hero should be able to equip Armor, the appropriate exceptions should be thrown if invalid (level requirement
and type)
• Total attributes should be calculated correctly
  o With no equipment
  o With one piece of armor
  o With two pieces of armor
  o With a replaced piece of armor (equip armor, then equip new armor in the same slot)
• Hero damage should be calculated properly
  o No weapon equipped
  o Weapon equipped
  o Replaced weapon equipped (equip a weapon then equip a new weapon)
  o Weapon and armor equipped
• Heroes should display their state correctly
