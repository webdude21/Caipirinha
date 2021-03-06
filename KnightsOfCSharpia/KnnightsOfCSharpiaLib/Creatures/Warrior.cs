﻿namespace KnightsOfCSharpiaLib.Creatures
{
    using System;
    using KnightsOfCSharpiaLib.Common;
    using KnightsOfCSharpiaLib.Engine;
    using KnightsOfCSharpiaLib.Exceptions;

    public class Warrior : Hero, IScalable, ICombatant
    {
        private const int SpecialAbilityManaCost = 50;
        private const DamageType SpecialAbilityType = DamageType.Physical;

        public Warrior(string name)
            : base(name)
        {
            this.Strength = 4;
            this.Dexterity = 5;
            this.Intelligence = 2;
            this.WillPower = 3;

            this.MaxMana = 100 + this.Intelligence * 10;
            this.CurrentMana = (int)this.MaxMana;
            this.MaxHealth += this.Dexterity * 10;
            this.CurrentHealth = (int)this.MaxHealth;
        }

        public override uint AttackPoints
        {
            get { return this.Strength * this.Level; }
        }

        public override string GetImageName
        {
            get
            {
                return @"creatures_Images\knight.png";
            }
        }

        public override uint DefensePoints(DamageType damageType)
        {
            switch (damageType)
            {
                case DamageType.Physical:
                    return (this.Dexterity * this.Level) / 2;
                case DamageType.Magical:
                    return (this.WillPower * this.Level) / 3;
                default:
                    throw new ArgumentException("Invalid damage type passed!");
            }
        }

        public override void LevelUp()
        {
            base.LevelUp();

            this.Strength++;
            this.Dexterity++;

            if (this.Level % 2 == 0)
            {
                this.Intelligence++;
                this.WillPower++;
            }

            this.MaxHealth += 100;
            this.CurrentHealth = (int)this.MaxHealth;
            this.MaxMana += 50;
        }
        
        public override AttackLog Attack(ICombatant target)
        {
            var attackResult = target.Defend(new AttackLog(DamageType.Physical, this.AttackPoints));

            attackResult.AttackInformation = String.Format("{0} uses basic attack on ", this.Name) + attackResult.AttackInformation;

            return attackResult;
        }

        public override AttackLog SpecialAttack(ICombatant target)
        {
            if (this.CurrentMana < SpecialAbilityManaCost)
            {
                throw new InsufficientManaException();
            }

            var attackResult = target.Defend(new AttackLog(SpecialAbilityType, this.AttackPoints * this.Strength));

            attackResult.AttackInformation = String.Format("{0} uses {1} on ", this.Name, RandomGenerator.GetRandomAbilityName(SpecialAbilityType)) + attackResult.AttackInformation;

            this.CurrentMana -= SpecialAbilityManaCost;

            return attackResult;
        }

    }
}