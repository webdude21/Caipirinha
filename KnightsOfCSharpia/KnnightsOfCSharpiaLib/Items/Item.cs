namespace KnightsOfCSharpiaLib.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using KnightsOfCSharpiaLib.Common;

    public class Item
    {
        private const int MinModifierValue = 0;

        private string name;

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

        public uint StrengthModifier { get; set; }

        public uint DexterityModifier { get; set; }

        public uint IntelligenceModifier { get; set; }

        public uint WillPowerModifier { get; set; }

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
            List<KeyValuePair<PropertyInfo, uint>> propertiesAndValues = new List<KeyValuePair<PropertyInfo, uint>>();

            // Get a list of unique indexes, so we can alter the value of that modifier.
            List<int> uniqueIndexes = RandomGenerator.GetUniqueValues(numberOfProperties, 0, properties.Count);

            // Gets the name of the modifier with maximum value, used when generating the name of the item.
            // Currently, this returns more or less the first set property with value other than 0,
            // since all modifiers are either zero or 1 || 2 (1 for Common and 2 for Rare) * playerLevel
            string maxModifierName = string.Empty;
            uint maxModifier = uint.MinValue;

            // Iterate over all properties
            // If the uniqueIndexes collection contains the current index
            // modify the value depending on the Rarity.
            // After that, add the property and it's value in the collection.
            for (int i = 0; i < properties.Count; i++)
            {
                uint modifier = 0;
                if (uniqueIndexes.Contains(i))
                {
                    if (rarity == ItemRarity.Common)
                    {
                        modifier = 1 * (uint)partyLevel;
                    }
                    else if (rarity == ItemRarity.Rare)
                    {
                        modifier = 2 * (uint)partyLevel;
                    }
                }

                // Gets the max modifier
                if (modifier > maxModifier)
                {
                    maxModifierName = properties[i].Name;
                    maxModifier = modifier;
                }

                propertiesAndValues.Add(new KeyValuePair<PropertyInfo, uint>(properties[i], modifier));
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

        public string ItemSpecs
        {
            get { return this.ToString(); }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(string.Format("This is the {0} item '{1}'. ", this.Rarity.ToString().ToLower(), this.name));
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(string.Format("Its type is {0}, and it takes {1} space(s) in the inventory. ", 
                this.GetType().Name.ToLower(), this.Size));
            if (StrengthModifier > 0 || WillPowerModifier > 0 || IntelligenceModifier > 0 || DexterityModifier > 0)
            {
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append("This item affects the following attributes: ");
                stringBuilder.Append(Environment.NewLine);
                if (StrengthModifier > 0)
                {
                    stringBuilder.Append(string.Format("Strenght +{0}", this.StrengthModifier));
                    stringBuilder.Append(Environment.NewLine);
                }
                if (DexterityModifier > 0)
                {
                    stringBuilder.Append(string.Format("Dexterity +{0}", this.DexterityModifier));
                    stringBuilder.Append(Environment.NewLine);
                }
                if (IntelligenceModifier > 0)
                {
                    stringBuilder.Append(string.Format("Intelligence +{0}", this.IntelligenceModifier));
                    stringBuilder.Append(Environment.NewLine);
                } 
                if (WillPowerModifier > 0)
                {
                    stringBuilder.Append(string.Format("WillPower +{0}", this.WillPowerModifier));
                }
            }

            return stringBuilder.ToString();
        }
    }
}