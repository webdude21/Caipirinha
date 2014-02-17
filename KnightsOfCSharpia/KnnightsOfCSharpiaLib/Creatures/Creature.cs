using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnightsOfCSharpia.Common;

namespace KnightsOfCSharpia.Creatures
{
    public class Creature : Unit
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

        public override Common.AttackLog Attack(Hero target)
        {
            throw new NotImplementedException();
        }

        public override string Defend(Spells.SpellDamage attackSpell)
        {
            throw new NotImplementedException();
        }
    }
}
