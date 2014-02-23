using KnnightsOfCSharpiaLib.Common;
using KnnightsOfCSharpiaLib.Spells;
using System;

namespace KnnightsOfCSharpiaLib.Creatures
{
    public abstract class Creature : Unit
    {
        private const uint DefaultAttackPoints = 2;
        private const uint DefaultDefencePoints = 3;

        public string Type { get; set; }

        protected Creature(String name, uint level = 1)
            : base(name, level)
        {
        }

        public override uint GetAttackPoints()
        {
            return Level * DefaultAttackPoints;
        }

        public override uint GetDeffencePoints()
        {
            return Level * DefaultDefencePoints;
        }
    }
}
