namespace KnightsOfCSharpia.Spells
{
    using System;

    public struct SpellDamage
    {
        public SpellDamage(string name, int damage, DamageTypeEnum damageType)
            :this()
        {
            this.SpellName = name;
            this.SpellDamageModifier = damage;
            this.DamageType = damageType;
        }

        public string SpellName { get; private set; }

        public int SpellDamageModifier { get; private set; }

        public DamageTypeEnum DamageType { get; private set; }
    }
}
