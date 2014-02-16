using System;
using KnightsOfCSharpia.Items;
using KnightsOfCSharpia.Common;

namespace KnightsOfCSharpia
{
    class KnightsOfCSharpia
    {
        static void Main()
        {
            var bla = Helmet.MakeRandom(2, ItemRarity.Rare);
            Item item = RandomGenerator.GenerateRandomItems(2);

            var test = Item.MakeRandom(2, ItemRarity.Common, "Helmet");
        }
    }
}
