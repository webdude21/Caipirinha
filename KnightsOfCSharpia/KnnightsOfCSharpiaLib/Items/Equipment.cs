using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightsOfCSharpiaLib.Items
{
    public class Equipment
    {
        private readonly List<Item> items = new List<Item>();

        public List<Item> Items
        {
            get
            {
                return new List<Item>(this.items);
            }
        }

        public void AddItem(Item item)
        {
            if (this.items.Any(x => (x.Type == item.Type)))
            {
                throw new InvalidOperationException("You can equip only one item of each type!");
            }
            this.Items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            this.Items.Remove(item);
        }
    }
}