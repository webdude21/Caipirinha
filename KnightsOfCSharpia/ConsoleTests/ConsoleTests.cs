using KnightsOfCSharpiaLib.Common;
using KnightsOfCSharpiaLib.Items;
using KnightsOfCSharpiaLib.Creatures;
using KnightsOfCSharpiaLib.Engine;
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

        Mage playerMage = new Mage("Pesho");
        playerMage.Inventory.AddItem(new Boots("Кожени Ботуши", ItemRarity.Common));
        playerMage.Inventory.AddItem(new Boots("Кожен боздуган", ItemRarity.Common));
        playerMage.Inventory.AddItem(new Belt("Кожен Колан", ItemRarity.Common));
        Console.WriteLine(playerMage.Inventory);

        EnemyMage enemyMage = new EnemyMage("Gosho", 1, MageType.Icemage);

        BattleEngine currentBattle = new BattleEngine(playerMage, enemyMage);

        bool playerTurn = true;

        while (true)
        {
            string command = string.Empty;

            if (playerTurn)
            {
                command = Console.ReadLine();
                playerTurn = false;
            }
            else
            {
                playerTurn = true;
            }

            Console.WriteLine(currentBattle.NextAttack(command));
        }
    }
}
