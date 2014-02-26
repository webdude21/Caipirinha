using System;
using System.Collections.ObjectModel;

namespace KnightsOfCSharpiaLib.Items
{
    public class LootCollection
    {
        private ObservableCollection<Item> lootContents;

        public LootCollection()
        {
            this.lootContents = new ObservableCollection<Item>();
        }

        public ObservableCollection<Item> Contents
        {
            get
            {
                return this.lootContents;
            }
            private set
            {
                this.lootContents = value;
            }
        }

        public void AddItem(Item itemToAdd)
        {
            if (itemToAdd == null)
            {
                throw new ArgumentNullException("Cannot add null values to the Loot collection!");
            }

            this.lootContents.Add(itemToAdd);
        }

        public void RemoveItem(Item itemToAdd)
        {
            this.lootContents.Remove(itemToAdd);
        }
    }
}
