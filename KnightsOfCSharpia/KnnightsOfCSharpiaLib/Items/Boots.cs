namespace KnightsOfCSharpiaLib.Items
{
    using System.Collections.Generic;
    using System.Reflection;

    public class Boots : Item
    {
        public const ItemType ItemSlot = ItemType.Feet;

        public const int ItemSize = 2;

        public Boots(string name, ItemRarity rarity)
            :base(name, ItemSlot, rarity, ItemSize)
        {
            
        }

        /// <summary>
        /// Creates a Helmet with randomly generated properties and values, which are passed in as a parameter.
        /// Access modifier: internal, since we only want to be able to use this constructor from the current assembly.
        /// </summary>
        /// <param name="name">Name of the item.</param>
        /// <param name="rarity">Rarity of the item.</param>
        /// <param name="propertiesAndValues">
        /// A collection of the Modifier properties with random values attached to them.
        /// This constructor shoul dnever be used, unless random values are pass on here!
        /// The base constructor takes care of the item Name, Type, Rarity and Size.
        /// After that, the selected properties are initialized using reflection.
        /// This constructor is generally used by the MakeRandom function!
        /// </param> 
        public Boots(string name, ItemRarity rarity, List<KeyValuePair<PropertyInfo, int>> propertiesAndValues)
            : this(name, rarity)
        {
            foreach (var propAndVal in propertiesAndValues)
            {
                propAndVal.Key.SetValue(this, propAndVal.Value);
            }
        }
    }
}