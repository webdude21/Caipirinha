using KnightsOfCSharpia.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace KnightsOfCSharpia.Items
{
    public class Helmet : Item
    {
        public const ItemType ItemSlot = ItemType.Head;

        public const int ItemSize = 2;

        /// <summary>
        /// Creates a "blank" Helmet.
        /// All it's modifiers are 0 by default.
        /// </summary>
        /// <param name="name">Name of the item.</param>
        /// <param name="rarity">Rarity of the item.</param>
        public Helmet(string name, ItemRarity rarity)
            :base(name, ItemSlot, rarity, ItemSize)
        {
        }

        /// <summary>
        /// Creates a Helmet with randomly generated properties and values, which are passed in as a parameter.
        /// Access modifier: internal, since we only want to be able to use this constructor from the current assembly.
        /// </summary>
        /// <param name="name">Name of the item.</param>
        /// <param name="rarity">Rarity of the item.</param>
        /// <param name="propertiesAndValues">A collection of the Modifier properties with random values attached to them.
        /// You should never used this constructor, unless you pass in random values here!</param>
        public Helmet(string name, ItemRarity rarity, List<KeyValuePair<PropertyInfo, int>> propertiesAndValues)
            : base(name, ItemSlot, rarity, ItemSize)
        {
            // The base constructor takes care of the item Name, Type, Rarity and Size.
            // After that, we initialise the selected properties using reflection.
            // This constructor is generally used by the MakeRandom function!
            foreach (var propAndVal in propertiesAndValues)
            {
                propAndVal.Key.SetValue(this, propAndVal.Value, null);
            }
        }
    }
}
