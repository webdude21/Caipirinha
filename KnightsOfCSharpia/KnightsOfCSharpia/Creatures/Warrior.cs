using System;
using System.Linq;
using KnightsOfCSharpia.Common;

namespace KnightsOfCSharpia
{
    public class Warrior : Hero
    {
        private const uint Strength = 15;
        private const uint Dexterity = 6;
        private const uint Intelligence = 2;
        private const uint Endurance = 12;

        public Warrior(string name)
            : base(name, Strength, Dexterity, Intelligence, Endurance)
        {
            
        }

        public override AttackLog Attack(Hero target)
        {
            if (target.IsAlive)
            {
                var currentAbility = this.Abilities["basic attack"];
                this.CurrentMana -= currentAbility.ManaCost;
                var attackResult = currentAbility.Effect(this.GetAttackPoints());

                string result = target.Defend(attackResult);
                return new AttackLog(true, String.Format("{0} uses {1} on {2}", this.Name, currentAbility.Name, result));
            }
            else
            {
                return AttackLog.AttackFailed;
            }
        }

        public override string Defend(Spells.SpellDamage attackSpell)
        {
            throw new NotImplementedException();
        }

        public void SpecialAttack()
        {
            throw new System.NotImplementedException();
        }
    }
}
