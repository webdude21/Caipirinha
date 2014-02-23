using System;

namespace KnnightsOfCSharpiaLib.Creatures
{
    public class Creature : Unit
    {
        private const uint DefaultAttackPoints = 2;
        private const uint DefaultDefencePoints = 3;
        
        public Creature(String name, uint level = 1)
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

        public override Common.AttackLog Attack(Hero target)
        {
            throw new NotImplementedException();
        }

        public override string Defend(Spells.SpellDamage attackSpell)
        {
            throw new NotImplementedException();
        }

        public override string Defend(SpellDamage attackSpell)
        {
            throw new NotImplementedException();
        }
    }
}
