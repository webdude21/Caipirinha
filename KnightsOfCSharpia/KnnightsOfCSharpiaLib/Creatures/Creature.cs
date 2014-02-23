using KnnightsOfCSharpiaLib.Spells;
using System;

namespace KnnightsOfCSharpiaLib.Creatures
{
    public class Creature : Unit
    {
        private const uint DefaultAttackPoints = 2;
        private const uint DefaultDefencePoints = 3;

        public string Type { get; set; }
        
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

        public Common.AttackLog Attack(Hero target)
        {
            throw new NotImplementedException();
        }

        public string Defend(Spells.SpellDamage attackSpell)
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override Common.AttackLog Attack(Unit target)
        {
            throw new NotImplementedException();
        }

        public override Common.AttackLog Defend(uint damage)
        {
            throw new NotImplementedException();
        }
    }
}
