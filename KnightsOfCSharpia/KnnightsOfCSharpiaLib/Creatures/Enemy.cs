using KnnightsOfCSharpiaLib.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnnightsOfCSharpiaLib.Creatures
{
    public class Enemy : Hero
    {
        public Enemy(string name, uint strength, uint dexterity, uint intelligence, uint willPower)
            :base(name, strength, dexterity, intelligence, willPower)
        {
            
        }

        public override uint GetDeffencePoints()
        {
            throw new NotImplementedException();
        }

        public override AttackLog Attack(Unit target)
        {
            throw new NotImplementedException();
        }

        public override AttackLog Defend(uint damage)
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
