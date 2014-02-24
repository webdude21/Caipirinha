namespace KnightsOfCSharpiaLib.Creatures
{
    using KnightsOfCSharpiaLib.Common;
    using KnightsOfCSharpiaLib.Engine;
    using KnightsOfCSharpiaLib.Exceptions;
    using System;

    public class EnemyMage : Creature, ICombatant, IEnemy
    {
        private const int DefaultPhysicalDamageDefensePoints = 2;
        private const int DefaultMagicalDamageDefensePoints = 3;
        private const int DefaultPhysicalDamageAttackPoints = 3;
        private const int DefaultMagicalDamageAttackPoints = 4;
        private const int SpecialAbilityManaCost = 70;

        public EnemyMage(string name, uint level, MageType type) : base(name, level)
        {
            this.Type = type.ToString();
            this.PhysicalDamageDefensePoints = DefaultPhysicalDamageDefensePoints;
            this.MagicalDamageDefensePoints = DefaultMagicalDamageDefensePoints;
            this.PhysicalDamageAttackPoints = DefaultPhysicalDamageAttackPoints;
            this.MagicalDamageAttackPoints = DefaultMagicalDamageAttackPoints;
        }

        public override uint AttackPoints
        {
            get
            {
                return this.MagicalDamageAttackPoints * this.Level;
            }
        }

        public override void Update()
        {
            this.CurrentMana += 5 + (int)this.Level * 2;

            if (this.CurrentMana > this.MaxMana)
            {
                this.CurrentMana = (int)this.MaxMana;
            }
        }

        public override AttackLog Attack(ICombatant target)
        {
            var attackResult = target.Defend(new AttackLog(DamageType.Physical, this.AttackPoints));

            attackResult.AttackInformation = string.Format("{0} uses basic attack on ", this.Name) + attackResult.AttackInformation;

            return attackResult;
        }

        public override AttackLog SpecialAttack(ICombatant target)
        {
            if (this.CurrentMana < SpecialAbilityManaCost)
            {
                throw new InsufficientManaException();
            }

            var attackResult = target.Defend(new AttackLog(DamageType.Magical, this.AttackPoints * 3));

            attackResult.AttackInformation = String.Format("{0} uses {1} on ", this.Name, RandomGenerator.GetRandomAbilityName(DamageType.Magical)) + attackResult.AttackInformation;

            this.CurrentMana -= SpecialAbilityManaCost;

            return attackResult;
        }

    }
}