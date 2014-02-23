using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KnightsOfCSharpiaLib.Items
{
    public class Armour : Item
    {
        public const ItemType ItemSlot = ItemType.Armour;

        public const int ItemSize = 6;

        public Armour(string name, ItemRarity rarity)
            :base(name, ItemSlot, rarity, ItemSize)
        {
            
        }

        public Armour(string name, ItemRarity rarity, List<KeyValuePair<PropertyInfo, int>> propertiesAndValues)
            :this(name, rarity)
        {
            foreach (var propAndVal in propertiesAndValues)
            {
                propAndVal.Key.SetValue(this, propAndVal.Value);
            }
        }

    }
}
