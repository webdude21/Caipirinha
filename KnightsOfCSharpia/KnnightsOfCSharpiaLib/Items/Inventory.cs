﻿using System.Collections.ObjectModel;

namespace KnightsOfCSharpiaLib
{
    using Items;
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using System.Text;

    [JsonObject(MemberSerialization.OptIn)]
    public class Inventory
    {
        public Inventory(uint capacity = 100)
        {
            InventoryContent = new ObservableCollection<Item>();
            Capacity = capacity;
        }

        [JsonProperty]
        public ObservableCollection<Item> InventoryContent { get; protected set; }

        [JsonProperty(Order=1)]
        public uint Capacity { get; private set; }

        public uint UsedSize
        {
            get { return (uint)InventoryContent.Sum(item => item.Size); }
        }

        public void AddItem(Item item)
        {
            if (item == null)
            {
                return;
            }
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

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            foreach (var item in InventoryContent)
            {
                stringBuilder.Append(item.Name);
                stringBuilder.Append(Environment.NewLine);
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}