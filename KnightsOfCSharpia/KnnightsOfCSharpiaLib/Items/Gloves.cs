using System;
using System.Collections.Generic;
using System.Reflection;

namespace KnightsOfCSharpiaLib.Items
{
    public class Gloves : Item
    {
        public const ItemType ItemSlot = ItemType.Arms;

        public const int ItemSize = 2;

        public Gloves(string name, ItemRarity rarity)
            :base(name, ItemSlot, rarity, ItemSize)
        {
            
        }

        public Gloves(string name, ItemRarity rarity, List<KeyValuePair<PropertyInfo, int>> propertiesAndValues)
            :this(name, rarity)
        {
            foreach (var propAndVal in propertiesAndValues)
            {
                propAndVal.Key.SetValue(this, propAndVal.Value);
            }
        }
    }
}
