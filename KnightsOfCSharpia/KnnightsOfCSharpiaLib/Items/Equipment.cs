using KnnightsOfCSharpiaLib.Items;
using System.Collections.Generic;

namespace KnnightsOfCSharpiaLib
{
    public class Equipment
    {
        private List<Item> items;

        public List<Item> Items
        {
            get
            {
                return new List<Item>(this.items);
            }
            private set
            {
                this.items = value;
            }
        }

        public void AddItem(Item item)
        {
            this.Items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            this.Items.Remove(item);
        }
    }
}
