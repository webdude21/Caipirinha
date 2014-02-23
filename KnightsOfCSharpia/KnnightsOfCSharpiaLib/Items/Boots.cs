using System.Collections.Generic;
using System.Reflection;

namespace KnnightsOfCSharpiaLib.Items
{
    public class Boots : Item
    {
        public const ItemType ItemSlot = ItemType.Shoes;

        public const int ItemSize = 2;

        public Boots(string name, ItemRarity rarity)
            :base(name, ItemSlot, rarity, ItemSize)
        {
            
        }

        public Boots(string name, ItemRarity rarity, List<KeyValuePair<PropertyInfo, int>> propertiesAndValues)
            : base(name, ItemSlot, rarity, ItemSize)
        {
            foreach (var propAndVal in propertiesAndValues)
            {
                propAndVal.Key.SetValue(this, propAndVal.Value, null);
            }
        }
    }
}
