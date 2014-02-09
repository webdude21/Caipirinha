using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsOfCSharpia
{
    class KnightsOfCSharpia
    {
        static void Main()
        {
            var drakon = new Creature("Зелен дракон", 10, 20);
            Console.WriteLine(drakon.GetAttackPoints());
        }
    }
}
