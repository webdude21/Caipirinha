namespace KnightsOfCSharpiaLib.Creatures
{
    using System;
    using KnightsOfCSharpiaLib.Common;
    using KnightsOfCSharpiaLib.Engine;
    using KnightsOfCSharpiaLib.Exceptions;

    public class Mage : Hero, IScalable, ICombatant
    {
        private const int SpecialAbilityManaCost = 70;
        private const DamageType SpecialAbilityType = DamageType.Magical;

        public Mage(string name)
            : base(name)
        {
            this.Strength = 2;
            this.Dexterity = 3;
            this.Intelligence = 4;
            this.WillPower = 5;

            this.MaxMana = 100 + this.Intelligence * 20;
            this.CurrentMana = (int)this.MaxMana;
            this.MaxHealth += this.WillPower * 10;
            this.CurrentHealth = (int)this.MaxHealth;
        }

        public override uint AttackPoints
        {
            get { return this.Intelligence * this.Level; }
        }

        public override uint DefensePoints(DamageType damageType)
        {
            switch (damageType)
            {
                case DamageType.Physical:
                    return (this.Dexterity * Level) / 3;
                    break;
                case DamageType.Magical:
                    return (this.WillPower * Level) / 2;
                    break;
                default:
                    throw new ArgumentException("Invalid damage type passed!");
                    break;
            }
        }

        public override AttackLog SpecialAttack(ICombatant target)
        {
            if (this.CurrentMana < SpecialAbilityManaCost)
            {
                throw new InsufficientManaException();
            }

            var attackResult = target.Defend(new AttackLog(SpecialAbilityType, this.AttackPoints * this.Intelligence));

            attackResult.AttackInformation = String.Format("{0} uses {1} on ", this.Name, RandomGenerator.GetRandomAbilityName(SpecialAbilityType)) + attackResult.AttackInformation;

            this.CurrentMana -= SpecialAbilityManaCost;

            return attackResult;
        }

        public override AttackLog Attack(ICombatant target)
        {
            var attackResult = target.Defend(new AttackLog(DamageType.Physical, this.AttackPoints));

            attackResult.AttackInformation = String.Format("{0} uses basic attack on ", this.Name) + attackResult.AttackInformation;

            return attackResult;
        }

        public override void LevelUp()
        {
            base.LevelUp();

            this.Intelligence++;
            this.WillPower++;

            if (this.Level % 2 == 0)
            {
                this.Strength++;
                this.Dexterity++;
            }

            this.MaxHealth = this.MaxHealth + 50;
            this.CurrentHealth = (int)this.MaxHealth;
            this.MaxMana = this.MaxMana + 100;
        }
    }
}