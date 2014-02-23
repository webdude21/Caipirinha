using System.Collections.Generic;
using System.Reflection;

namespace KnnightsOfCSharpiaLib.Items
{
    public class Staff : Item
    {
        public const ItemType ItemSlot = ItemType.Weapon;

        public const int ItemSize = 5;

        public Staff(string name, ItemRarity rarity)
            :base(name, ItemSlot, rarity, ItemSize)
        {
            
        }

        public Staff(string name, ItemRarity rarity, List<KeyValuePair<PropertyInfo, int>> propertiesAndValues)
            :this(name, rarity)
        {
            foreach (var propAndVal in propertiesAndValues)
            {
                propAndVal.Key.SetValue(this, propAndVal.Value, null);
            }
        }
    }
}
