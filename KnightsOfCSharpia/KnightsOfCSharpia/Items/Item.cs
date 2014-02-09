using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightsOfCSharpia.Items
{
    public class Item
    {
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
