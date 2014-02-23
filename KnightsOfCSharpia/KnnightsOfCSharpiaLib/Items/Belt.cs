using System.Collections.Generic;
using System.Reflection;

namespace KnnightsOfCSharpiaLib.Items
{
    public class Belt : Item
    {
        public const ItemType ItemSlot = ItemType.Belt;

        public const int ItemSize = 2;

        public Belt(string name, ItemRarity rarity)
            : base(name, ItemSlot, rarity, ItemSize)
        {

        }

        public Belt(string name, ItemRarity rarity, List<KeyValuePair<PropertyInfo, int>> propertiesAndValues)
            : this(name, rarity)
        {
            foreach (var propAndVal in propertiesAndValues)
            {
                propAndVal.Key.SetValue(this, propAndVal.Value);
            }
        }
    }
}
