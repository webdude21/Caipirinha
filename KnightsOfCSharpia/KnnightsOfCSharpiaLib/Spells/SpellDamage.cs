namespace KnightsOfCSharpiaLib.Spells
{
    public struct SpellDamage
    {
        public SpellDamage(string name, uint damage, DamageType damageType)
            :this()
        {
            this.SpellName = name;
            this.SpellDamageModifier = damage;
            this.DamageType = damageType;
        }

        public string SpellName { get; private set; }

        public uint SpellDamageModifier { get; private set; }

        public DamageType DamageType { get; private set; }
    }
}
