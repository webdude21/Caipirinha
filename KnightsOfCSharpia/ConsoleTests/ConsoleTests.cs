using KnightsOfCSharpiaLib.Common;
using KnightsOfCSharpiaLib.Items;
using System;
using System.Collections.Generic;

class ConsoleTests
{
    static void Main()
    {
        Item genItem = RandomGenerator.GenerateRandomItem(2);
        var items = new List<Item>();

        for (int i = 0; i < 20; i++)
        {
            items.Add(RandomGenerator.GenerateRandomItem(2));
            Console.WriteLine(items[i].Rarity);
        }
    }
}
