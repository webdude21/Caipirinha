namespace KnightsOfCSharpiaLib.Common
{
    /// <summary>
    /// A random generator class, which generates random numbers,
    /// sequences of unique values and items.
    /// </summary>
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Engine;
    using Items;

    public static class RandomGenerator
    {
        private static readonly Random generator;

        private readonly static string[] warriorAbilityNames = new string[]
        {
            "Cleave",
            "Mutilate",
            "Slash",
            "Rend",
            "Charge"
        };

        private readonly static string[] mageAbilityNames = new string[]
        {
            "Fireball",
            "Frostbolt",
            "Scorch",
            "Immolate",
            "Freeze",
            "Arcane bolt"
        };

        static RandomGenerator()
        {
            generator = new Random();
        }

        public static int GetRandomValue(int minValue, int maxValue)
        {
            return generator.Next(minValue, maxValue);
        }

        public static List<int> GetUniqueValues(int numberOfValues, int minValue, int maxValue)
        {
            List<int> values = new List<int>();

            for (int i = 0; i < numberOfValues; i++)
            {
                int value = generator.Next(minValue, maxValue);
                while (values.Contains(value))
                {
                    value = generator.Next(minValue, maxValue);
                }
                values.Add(value);
            }

            return values;
        }

        /// <summary>
        /// Generates a random item with random rarity.
        /// The item is derived from the subclasses of Item class
        /// I.E. a random Rare quality helmet.
        /// </summary>
        /// <param name="partyLevel">The level of the party for which the item is dropped</param>
        /// <returns></returns>
        public static Item GenerateRandomItem(int partyLevel)
        {
            // There's a 10% chance for a Rare item drop.
            ItemRarity rarity;
            if (RandomGenerator.GetRandomValue(0, 101) <= 20)
            {
                rarity = ItemRarity.Rare;
            }
            else
            {
                rarity = ItemRarity.Common;
            }

            // Using reflection, get all child classes of Item, i.e. Helmet
            var targetAssembly = Assembly.GetExecutingAssembly();
            var childrenOfItemClass = targetAssembly.GetTypes().Where(x => x.IsSubclassOf(typeof(Item))).ToList();

            // Select a random class from them.
            int randomIndexOfChildren = RandomGenerator.GetRandomValue(0, childrenOfItemClass.Count);
            Type selectedType = childrenOfItemClass[randomIndexOfChildren];

            // Invoke the MakeRandom method of the class, which creates an item based on the parameters provided
            // In this case, we provide partyLevel and rarity of the item, and the static method of the item handles the rest.
            MethodInfo method = typeof(Item).GetMethod("MakeRandom", BindingFlags.NonPublic | BindingFlags.Static).MakeGenericMethod(selectedType);

            // Returns an Object type of the desired item
            var result = method.Invoke(null, new object[] { partyLevel, rarity });

            // Casts the resulting item to Item for polymorphism and easier method use (otherwise this too will be a generic method, which defeats the purpose)
            return result as Item;
        }

        internal static string GetRandomAbilityName(DamageType type)
        {
            switch (type)
            {
                case DamageType.Physical:
                    return warriorAbilityNames[GetRandomValue(0, warriorAbilityNames.Length)];
                case DamageType.Magical:
                    return mageAbilityNames[GetRandomValue(0, mageAbilityNames.Length)];
                default:
                    throw new ArgumentException("Invalid ability type passed!");
            }
        }
    }
}