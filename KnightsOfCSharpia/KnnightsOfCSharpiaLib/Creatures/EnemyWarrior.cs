namespace KnightsOfCSharpiaLib.Creatures
{
    using KnightsOfCSharpiaLib.Common;
    using KnightsOfCSharpiaLib.Engine;
    using KnightsOfCSharpiaLib.Exceptions;
    using System;

    public class EnemyWarrior : Creature, ICombatant, IEnemy
    {
        private const int DefaultPhysicalDamageDefensePoints = 3;
        private const int DefaultMagicalDamageDefensePoints = 2;
        private const int DefaultPhysicalDamageAttackPoints = 4;
        private const int DefaultMagicalDamageAttackPoints = 3;
        private const int SpecialAbilitiyManaCost = 50;

        public EnemyWarrior(string name, uint level, WarriorType type) : base(name, level)
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
                return this.PhysicalDamageAttackPoints * this.Level;
            }
        }

        public override void Update()
        {
            this.CurrentMana += 5 + (int)this.Level;

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
            if (this.CurrentMana < SpecialAbilitiyManaCost)
            {
                throw new InsufficientManaException();
            }

            var attackResult = target.Defend(new AttackLog(DamageType.Physical, this.AttackPoints * 2));

            attackResult.AttackInformation = String.Format("{0} uses {1} on ", this.Name, RandomGenerator.GetRandomAbilityName(DamageType.Physical)) + attackResult.AttackInformation;

            this.CurrentMana -= SpecialAbilitiyManaCost;

            return attackResult;
        }

    }
}