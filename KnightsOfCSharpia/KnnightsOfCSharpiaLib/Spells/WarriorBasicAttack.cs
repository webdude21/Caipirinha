namespace KnnightsOfCSharpiaLib.Spells
{
    using System;

    public class WarriorBasicAttack : Spell
    {
        private const string SpellName = "Basic attack";
        private const string SpellDescription = "A basic attack with your sword";

        public WarriorBasicAttack()
            :base(true, false, 0, SpellName, SpellDescription)
        {
            this.DamageType = DamageTypeEnum.Physical;
        }

        public DamageTypeEnum DamageType { get; private set; }

        public override SpellDamage Effect(uint casterModifier)
        {
            return new SpellDamage(SpellName, casterModifier, this.DamageType);
        }
    }
}
