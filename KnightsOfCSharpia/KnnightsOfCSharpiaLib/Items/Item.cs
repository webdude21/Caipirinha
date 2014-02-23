namespace KnightsOfCSharpiaLib.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Common;
    public class Item
    {   
        private const int MinModifierValue = 0;

        private string name;
        private int strengthModifier;
        private int dexterityModifier;
        private int intelligenceModifier;
        private int willPowerModifier;

        // Since when creating an object, the parent constructor is the first one that gets called (when specified)
        // Initialize all modifiers to 0 and then change the desired ones from the child constructor
        public Item(string itemName, ItemType type, ItemRarity rarity, int itemSize)
        {
            this.Name = itemName;
            this.Type = type;
            this.Rarity = rarity;
            this.Size = itemSize;

            this.StrengthModifier = MinModifierValue;
            this.DexterityModifier = MinModifierValue;
            this.IntelligenceModifier = MinModifierValue;
            this.WillPowerModifier = MinModifierValue;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name", "The item has no name");
                }

                this.name = value;
            }
        }

        public ItemType Type { get; set; }

        public ItemRarity Rarity { get; set; }

        public int Size { get; set; }

        public int StrengthModifier
        {
            get
            {
                return this.strengthModifier;
            }
            set
            {
                if (value < MinModifierValue)
                {
                    throw new ArgumentException("StrengthModifier", "Value can't be negative");
                }

                this.strengthModifier = value;
            }
        }

        public int DexterityModifier
        {
            get
            {
                return this.dexterityModifier;
            }
            set
            {
                if (value < MinModifierValue)
                {
                    throw new ArgumentException("DexterityModifier", "Value can't be negative");
                }

                this.dexterityModifier = value;
            }
        }

        public int IntelligenceModifier
        {
            get
            {
                return this.intelligenceModifier;
            }
            set
            {
                if (value < MinModifierValue)
                {
                    throw new ArgumentException("IntelligenceModifier", "Value can't be negative");
                }

                this.intelligenceModifier = value;
            }
        }
        
        public int WillPowerModifier
        {
            get
            {
                return this.willPowerModifier;
            }
            set
            {
                if (value < MinModifierValue)
                {
                    throw new ArgumentException("WillPowerModifier", "Value can't be negative");
                }

                this.willPowerModifier = value;
            }
        }

        internal static T MakeRandom<T>(int partyLevel, ItemRarity rarity) where T : Item
        {
            // Determine a random number of properties to modify
            // 2-4 for Rare items
            // 1-2 for Common items
            int numberOfProperties = 0;

            if (rarity == ItemRarity.Rare)
            {
                numberOfProperties = RandomGenerator.GetRandomValue(2, 5);
            }
            else if (rarity == ItemRarity.Common)
            {
                numberOfProperties = RandomGenerator.GetRandomValue(1, 3);
            }

            Type variable = typeof(T);

            // Get a list of all stat modifiers of this type using reflection.
            List<PropertyInfo> properties = variable.GetProperties().Where(x => x.Name.Contains("Modifier")).ToList();

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

            string itemName = String.Format("{0} of {1}", variable.Name, modifierName);

            // Get the size of the item (how much slots in the inventory it takes) and the equipment slot it occupies
            int itemSize = (int)variable.GetField("ItemSize", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy).GetValue(null);

            ItemType itemSlot = (ItemType)variable.GetField("ItemSlot", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy).GetValue(null);

            object instance = Activator.CreateInstance(variable, itemName, rarity, propertiesAndValues);

            return instance as T;
        }
    }
}