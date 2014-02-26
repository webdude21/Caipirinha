namespace KnightsOfCSharpiaLib.Creatures
{
    using KnightsOfCSharpiaLib.Engine;
    using System;
    public abstract class Creature : Unit, ICombatant, IEnemy
    {
        protected Creature(String name, uint level = 1)
            : base(name, level)
        {
            this.MaxMana = 100 + this.Level * 10;
            this.CurrentMana = (int)this.MaxMana;
        }

        public string Type { get; set; }

        public uint XPYield
        {
            get
            {
                return 60 + this.Level * 10;
            }
        }

        protected uint PhysicalDamageDefensePoints { get; set; }
        protected uint MagicalDamageDefensePoints { get; set; }
        protected uint PhysicalDamageAttackPoints { get; set; }
        protected uint MagicalDamageAttackPoints { get; set; }

        public override uint DefensePoints(DamageType damageType)
        {
            switch (damageType)
            {
                case DamageType.Physical:
                    return this.PhysicalDamageDefensePoints * this.Level;
                case DamageType.Magical:
                    return this.MagicalDamageDefensePoints * this.Level;
                default:
                    throw new ArgumentException("Invalid damage type parameter passed!");
            }
        }

        public string GetImageName
        {
            get
            {
                return @"creatures_Images\" + this.Type.ToLower() + ".png";
            }
        }
    }
}