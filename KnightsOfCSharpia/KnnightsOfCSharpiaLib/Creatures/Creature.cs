namespace KnightsOfCSharpiaLib.Creatures
{
    using System;
    public abstract class Creature : Unit, ICombatant
    {
        private const uint DefaultAttackPoints = 2;
        private const uint DefaultDefencePoints = 3;

        protected Creature(String name, uint level = 1)
            : base(name, level)
        {
        }

        public string Type { get; set; }
    }
}