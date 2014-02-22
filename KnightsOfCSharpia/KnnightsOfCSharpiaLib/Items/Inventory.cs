using KnightsOfCSharpia.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightsOfCSharpia
{
    public class Inventory
    {
        private readonly List<Item> items = new List<Item>();

        public Inventory(uint capacity = 100)
        {
            Capacity = capacity;
        }

        public uint Capacity { get; private set; }


        public uint UsedSize
        {
            get { return (uint)items.Sum(item => item.Size); }
        }

        public void AddItem(Item item)
        {
            if (item.Size + this.UsedSize > Capacity)
            {
                throw new InvalidOperationException("The inventory is full!");
            }

            items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        public void Clear()
        {
            items.Clear();
        }
    }
}
