using KnightsOfCSharpia.Spells;
using KnightsOfCSharpia.Common;
using System;

namespace KnightsOfCSharpia.Creatures
{
    public class Worrior : Creature
    {

        public Worrior()
            :base()
        {
            this.Abilities.AddSpell(new WarriorBasicAttack());
        }

        public override AttackLog Attack(Creature target)
        {
            if (target.IsAlive)
            {
                var currentAbility = this.Abilities["basic attack"];
                this.CurrentMana -= currentAbility.ManaCost;
                var attackResult = currentAbility.Effect(this.AttackPoints);

                string result = target.Deffend(attackResult);
                return new AttackLog(true, String.Format("{0} uses {1} on {2}", this.Name, currentAbility.Name, result));
            }
            else
            {
                return AttackLog.AttackFailed;
            }
        }

        public override string Deffend(SpellDamage attackSpell)
        {
            throw new NotImplementedException();
        }
    }
}
