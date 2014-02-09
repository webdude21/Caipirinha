using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsOfCSharpia
{
    public class Inventory
    {
        private static int capacity;
        private static int usedCapacity;
        private static List<Item> items;

        public uint UsedSize
        {
            get { return (uint)items.Sum(item => item.Size); }
        }
    }
}
