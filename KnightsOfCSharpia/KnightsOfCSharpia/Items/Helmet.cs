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
        /// <summary>
        /// Generates a random Helmet.
        /// </summary>
        /// <param name="partyLevel">The level of the player for which this helmet is dropped
        /// Used to introduce some scaling and balance to the random generation</param>
        /// <param name="rarity">The rarity of the item you want.</param>
        /// <returns>Helmet</returns>
        public static Helmet MakeRandom(int partyLevel, ItemRarity rarity)
        {
            // First, determine a random number of properties to modify
            // 3-5 for Rare items
            // 1-3 for Common items
            int numberOfProperties = 0;

            if (rarity == ItemRarity.Rare)
            {
                numberOfProperties = RandomGenerator.GetRandomValue(3, 6);
            }
            else if (rarity == ItemRarity.Common)
            {
                numberOfProperties = RandomGenerator.GetRandomValue(1, 4);
            }

            // Get a list of all stat modifiers of this type using reflection.
            List<PropertyInfo> properties = typeof(Helmet).GetProperties().Where(x => x.Name.Contains("Modifier")).ToList();

            // A list which holds all modifiers and values (0 be default).
            List<KeyValuePair<PropertyInfo, int>> propertiesAndValues = new List<KeyValuePair<PropertyInfo, int>>();

            // Get a list of unique indexes, so we can alter the value of that modifier.
            List<int> uniqueIndexes = RandomGenerator.GetUniqueValues(numberOfProperties, 0, properties.Count);

            // Gets the name of the modifier with maximum value, used when generating the name of the item.
            // Currently, this returns more or less the first set property with value other than 0,
            // since all modifiers are either zero or 1 || 2 (1 for Common and 2 for Rare) * playerLevel
            string maxModifierName = string.Empty;
            int maxModifier = int.MinValue;

            // Iterate over all properties
            // If the uniqueIndexes collection contains the current index
            // modify the value depending on the Rarity.
            // After that, add the property and it's value in the collection.
            for (int i = 0; i < properties.Count; i++)
            {
                int modifier = 0;
                if (uniqueIndexes.Contains(i))
                {
                    if (rarity == ItemRarity.Common)
                    {
                        modifier = 1 * partyLevel;
                    }
                    else if (rarity == ItemRarity.Rare)
                    {
                        modifier = 2 * partyLevel;
                    }
                }

                // Gets the max modifier
                if (modifier > maxModifier)
                {
                    maxModifierName = properties[i].Name;
                    maxModifier = modifier;
                }

                propertiesAndValues.Add(new KeyValuePair<PropertyInfo, int>(properties[i], modifier));
            }

            // Generate random name for the item
            // Basically this takes the property name with the highest value
            // so if we change property names, we have to make sure they are relevant
            // or this method will generate items with reaaally funky names.

            StringBuilder modifierName = new StringBuilder();
            modifierName.Append(maxModifierName[0]);
            for (int i = 1; i < maxModifierName.Length; i++)
            {
                char currentChar = maxModifierName[i];
                if (currentChar == Char.ToUpper(currentChar))
                {
                    break;
                }
                modifierName.Append(currentChar);
            }

            string itemName = String.Format("Helmet of {0}", modifierName);

            // finally call the constructor which takes the properties and values as a parameter
            return new Helmet(itemName, ItemRarity.Common, propertiesAndValues);
        }

        /// <summary>
        /// Creates a "blank" Helmet.
        /// All it's modifiers are 0 by default.
        /// </summary>
        /// <param name="name">Name of the item.</param>
        /// <param name="rarity">Rarity of the item.</param>
        public Helmet(string name, ItemRarity rarity)
            :base(name, ItemType.Head, rarity, 2)
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
        internal Helmet(string name, ItemRarity rarity, List<KeyValuePair<PropertyInfo, int>> propertiesAndValues)
            :base(name, ItemType.Head, rarity, 2)
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
