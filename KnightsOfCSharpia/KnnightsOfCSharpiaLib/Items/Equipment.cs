using System.ComponentModel;
using System.Runtime.CompilerServices;
using KnightsOfCSharpiaLib.Annotations;

namespace KnightsOfCSharpiaLib.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Equipment : INotifyPropertyChanged
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
            if (item == null)
            {
                return;
            }
            if (this.items.Any(x => item != null && (x.Type == item.Type)))
            {
                throw new InvalidOperationException("You can equip only one item of each type!");
            }
            this.items.Add(item);
            OnPropertyChanged();
        }

        public void RemoveItem(Item item)
        {
            this.items.Remove(item);
            OnPropertyChanged();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}