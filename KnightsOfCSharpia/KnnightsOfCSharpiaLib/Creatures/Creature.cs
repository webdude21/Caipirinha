using System;

namespace KnightsOfCSharpiaLib.Creatures
{
    public abstract class Creature : Unit, ICombatant
    {
        private const uint DefaultAttackPoints = 2;
        private const uint DefaultDefencePoints = 3;

        public string Type { get; set; }

        protected Creature(String name, uint level = 1)
            : base(name, level)
        {
        }
    }
}
