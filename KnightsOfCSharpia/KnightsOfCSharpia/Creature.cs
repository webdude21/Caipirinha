using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsOfCSharpia
{
    class Creature : Unit
    {
        private uint attackPoints;

        public Creature(String name, uint attackPoints, uint level)
            : base(name)
        {
            this.attackPoints = attackPoints;
            this.Level = level;
        }

        public override uint GetAttackPoints()
        {
            return Level * this.attackPoints;
        }
    }
}
