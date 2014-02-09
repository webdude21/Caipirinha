using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsOfCSharpia.Spells
{
    public class MageBasicAttack : Spell
    {
        private const string SpellName = "Basic Attack";
        private const string SpellDescription = "A basic attack with your staff";

        public MageBasicAttack()
            : base(true, false, 0, SpellName, SpellDescription)
        {
            this.DamageType = DamageTypeEnum.Physical;
        }

        public DamageTypeEnum DamageType { get; private set; }

        // Returns a SpellDamage log which can be used when calling the creature Defend abilit;
        // In this case, this spell deals no extra damage outside the casterModifier
        public override SpellDamage Effect(int casterModifier)
        {
            return new SpellDamage(SpellName, casterModifier, this.DamageType);
        }
    }
}
