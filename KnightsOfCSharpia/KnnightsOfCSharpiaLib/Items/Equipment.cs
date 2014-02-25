using System.Collections.ObjectModel;

namespace KnightsOfCSharpiaLib.Items
{
    using System;
    using System.Linq;

    public class Equipment
    {
        public Equipment()
        {
            this.Items = new ObservableCollection<Item>();
        }
        public ObservableCollection<Item> Items { get; protected set; }

        public void AddItem(Item item)
        {
            if (item == null)
            {
                return;
            }
            if (this.Items.Any(x => item != null && (x.Type == item.Type)))
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