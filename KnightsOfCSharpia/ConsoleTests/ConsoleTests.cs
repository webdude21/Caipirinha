using KnightsOfCSharpiaLib.Common;
using KnightsOfCSharpiaLib.Creatures;

class ConsoleTests
{
    static void Main()
    {
        var loot = RandomGenerator.GenerateRandomItem(2);

        Mage pesho = new Mage("Pesho");

        pesho.Inventory.AddItem(loot.Contents[0]);
    }
}
