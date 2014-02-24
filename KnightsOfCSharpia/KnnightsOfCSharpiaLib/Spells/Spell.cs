namespace KnightsOfCSharpiaLib.Spells
{
    public abstract class Spell
    {
        public Spell(bool affectsEnemy, bool affectsCaster, int manaCost, string name, string description)
        {
            
        }

        public bool AffectsEnemy { get; private set; }

        public bool AffectsCaster { get; private set; }

        public uint ManaCost { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public abstract SpellDamage Effect(uint casterModifier);
    }
}