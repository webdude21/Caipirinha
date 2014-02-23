namespace KnightsOfCSharpiaLib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Items;
    public class Inventory
    {
        public Inventory(uint capacity = 100)
        {
            InventoryContent = new List<Item>();
            Capacity = capacity;
        }

        public List<Item> InventoryContent { get; protected set; }
        public uint Capacity { get; private set; }

        public uint UsedSize
        {
            get { return (uint)InventoryContent.Sum(item => item.Size); }
        }

        public void AddItem(Item item)
        {
            if (item.Size + this.UsedSize > Capacity)
            {
                throw new InvalidOperationException("The inventory is full!");
            }

            InventoryContent.Add(item);
        }

        public void RemoveItem(Item item)
        {
            InventoryContent.Remove(item);
        }

        public void Clear()
        {
            InventoryContent.Clear();
        }
    }
}