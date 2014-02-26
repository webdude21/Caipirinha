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
using KnightsOfCSharpiaLib.Creatures;

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

        private readonly static string[] enemyNames = new string[]
        {
            "Crush Bane",
            "Thorn Seer",
            "Speed Zephyr",
            "Smash Mace",
            "Mace",
            "Hunter",
            "Dreven",
            "Frug",
            "Yerghug",
            "Buordud",
            "Clog"
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
        public static LootCollection GenerateRandomItem(uint partyLevel)
        {
            LootCollection result = new LootCollection();

            // 50% chance for loot drop
            if (generator.Next() % 2 == 1)
            {
                return result;
            }
            
            // There's a 20% chance for a Rare item drop.
            ItemRarity rarity;
            if (RandomGenerator.GetRandomValue(0, 101) <= 20)
            {
                rarity = ItemRarity.Rare;
            }
            else
            {
                rarity = ItemRarity.Common;
            }

            int generatedItemsNumber;

            if (rarity == ItemRarity.Rare)
            {
                generatedItemsNumber = 1;
            }
            else
            {
                generatedItemsNumber = GetRandomValue(1, 4);
            }

            for (int i = 0; i < generatedItemsNumber; i++)
            {
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
                var generatedItem = method.Invoke(null, new object[] { (int)partyLevel, rarity });

                result.AddItem(generatedItem as Item);
            }

            return result;
        }

        public static Creature GetRandomEnemy(uint level)
        {
            Creature enemy;

            if (generator.Next() % 2 == 0)
            {
                int enumCount = Enum.GetValues(typeof(MageType)).Length;

                MageType mageType = (MageType)GetRandomValue(0, enumCount);

                enemy = new EnemyMage(GetRandomEnemyName(), level, mageType);
            }
            else
            {
                int enumCount = Enum.GetValues(typeof(WarriorType)).Length;

                WarriorType warriorType = (WarriorType)GetRandomValue(0, enumCount);

                enemy = new EnemyWarrior(GetRandomEnemyName(), level, warriorType);
            }

            return enemy;
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

        private static string GetRandomEnemyName()
        {
            return enemyNames[GetRandomValue(0, enemyNames.Length)];
        }
    }
}