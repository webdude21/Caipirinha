using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KnightsOfCSharpia.Spells;
using KnightsOfCSharpia.Common;

namespace KnightsOfCSharpia
{
    public class Mage : Hero
    {
        private const uint Strength = 4;
        private const uint Dexterity = 8;
        private const uint Intelligence = 16;
        private const uint Endurance = 7;

        public Mage(string name)
            : base(name, Strength, Dexterity, Intelligence, Endurance)
        {
            this.Abilities.AddSpell(new MageBasicAttack());
        }

        // Returns AttackLog, so we can see if the attack has passed
        // And if it passed, the details about it:
        // What type of damage is dealt, what ability was used, how much damage was dealt
        public override AttackLog Attack(Hero target)
        {
            if (target.IsAlive)
            {
                // Here the computer generated oponents can decide what attack to use
                // For now it's only basic attack
                var spellUsed = this.Abilities["basic attack"];
                var spellCastResult = spellUsed.Effect(this.GetAttackPoints());
                this.CurrentMana -= spellUsed.ManaCost;

                string result = target.Defend(spellCastResult);
                return new AttackLog(true, String.Format("{0} uses {1} on {2}", this.Name, spellUsed.Name, result));
            }
            else
            {
                return AttackLog.AttackFailed;
            }
        }

        public override string Defend(SpellDamage attackSpell)
        {
            // Here we can check the type of damage dealt and apply the correct response
            // Right now the two scenarios are the same, since we don't have separate defences for each type of attack
            // Right now, the return string is not quite accurate, since (if we decide on it) each character could be able to dodge
            // the attack, since returning an attack failed.
            uint resultingDamage = 0;

            if (attackSpell.DamageType == DamageTypeEnum.Physical)
            {
                resultingDamage = this.DefencePoints - attackSpell.SpellDamageModifier;
            }
            else
            {
                resultingDamage = this.DefencePoints - attackSpell.SpellDamageModifier;
            }

            return String.Format("{0} for {1} {2} damage. Remaining HP: {3}", this.Name, resultingDamage, attackSpell.DamageType, this.CurrentHealth);
        }

        public void Cast(Spell spell)
        {
            throw new System.NotImplementedException();
        }
    }
}
