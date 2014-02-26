using KnightsOfCSharpiaLib.Common;
using KnightsOfCSharpiaLib.Items;
using KnightsOfCSharpiaLib.Creatures;
using KnightsOfCSharpiaLib.Engine;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

class ConsoleTests
{
    static void Main()
    {
        var loot = RandomGenerator.GenerateRandomItem(2);

        Mage pesho = new Mage("Pesho");

        pesho.Inventory.AddItem(loot.Contents[0]);
    }
}
