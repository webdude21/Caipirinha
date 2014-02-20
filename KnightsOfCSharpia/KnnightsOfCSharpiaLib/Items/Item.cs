using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KnightsOfCSharpia.Common;
using System.Reflection;

namespace KnightsOfCSharpia.Items
{
    public class Item
    {
        internal static T MakeRandom<T>(int partyLevel, ItemRarity rarity) where T : Item
        {
            // Then, determine a random number of properties to modify
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

            return (T)instance;
        }

        private string name;
        private ItemType type;
        private ItemRarity rarity;
        private int size;
        private int healthModifier;
        private int manaModifier;
        private int strenghtModifier;
        private int defenceModifier;
        private int dexterityModifier;
        private int intelligenceModifier;
        private int enduranceModifier;
        private int attackPointsModifier;
        private int defencePointsModifier;

        // Since when creating an object, the parent constructor is the first one that gets called (when specified)
        // Initialize all modifiers to 0 and then change the desired ones from the child constructor
        public Item(string itemName, ItemType type, ItemRarity rarity, int itemSize)
        {
            this.Name = itemName;
            this.Type = type;
            this.Rarity = rarity;
            this.Size = itemSize;

            this.HealthModifier = 0;
            this.ManaModifier = 0;
            this.StrenghtModifier = 0;
            this.DefenceModifier = 0;
            this.DexterityModifier = 0;
            this.IntelligenceModifier = 0;
            this.EnduranceModifier = 0;
            this.AttackPointsModifier = 0;
            this.DefencePointsModifier = 0;
        }

        public Item(string itemName, ItemType type, ItemRarity rarity, int itemSize, List<KeyValuePair<PropertyInfo, int>> propertiesAndValues)
            :this(itemName, type, rarity, itemSize)
        {
            foreach (var propAndVal in propertiesAndValues)
            {
                propAndVal.Key.SetValue(this, propAndVal.Value, null);
            }
        }

        public int DefencePointsModifier
        {
            get
            {
                return this.defencePointsModifier;
            }
            set
            {
                this.defencePointsModifier = value;
            }
        }

        public int AttackPointsModifier
        {
            get
            {
                return this.attackPointsModifier;
            }
            set
            {
                this.attackPointsModifier = value;
            }
        }

        public int EnduranceModifier
        {
            get
            {
                return this.enduranceModifier;
            }
            set
            {
                this.enduranceModifier = value;
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
                this.intelligenceModifier = value;
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
                this.dexterityModifier = value;
            }
        }

        public int DefenceModifier
        {
            get
            {
                return this.defenceModifier;
            }
            set
            {
                this.defenceModifier = value;
            }
        }

        public int StrenghtModifier
        {
            get
            {
                return this.strenghtModifier;
            }
            set
            {
                this.strenghtModifier = value;
            }
        }

        public int ManaModifier
        {
            get
            {
                return this.manaModifier;
            }
            set
            {
                this.manaModifier = value;
            }
        }

        public int HealthModifier
        {
            get
            {
                return this.healthModifier;
            }
            set
            {
                this.healthModifier = value;
            }
        }

        public int Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }

        public ItemRarity Rarity
        {
            get
            {
                return this.rarity;
            }
            set
            {
                this.rarity = value;
            }
        }

        public ItemType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
    }
}
