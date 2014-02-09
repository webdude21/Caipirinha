using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightsOfCSharpia
{
    public class Item
    {
        private string name;
        private ItemType type;
        private uint size;
        private int healthModifier;
        private int manaModifier;
        private int strenghtModifier;
        private int defenceModifier;
        private int dexterityModifier;
        private int intelligenceModifier;
        private int enduranceModifier;
        private int attackPointsModifier;
        private int defencePointsModifier;

        public uint Size
        {
            get { return this.size; }
            set { this.size = value; }
        }
    }
}
