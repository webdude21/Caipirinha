using System.Collections.Generic;
using System.Reflection;

namespace KnightsOfCSharpiaLib.Items
{
    public class Sword : Item
    {
        public const ItemType ItemSlot = ItemType.Weapon;

        public const int ItemSize = 4;

        public Sword(string name, ItemRarity rarity)
            :base(name, ItemSlot, rarity, ItemSize)
        {
            
        }

        public Sword(string name, ItemRarity rarity, List<KeyValuePair<PropertyInfo, int>> propertiesAndValues)
            :this(name, rarity)
        {
            foreach (var propAndVal in propertiesAndValues)
            {
                propAndVal.Key.SetValue(this, propAndVal.Value);
            }
        }
    }
}
