using KnightsOfCSharpiaLib.Engine;
using System;

namespace KnightsOfCSharpiaLib.Creatures
{
    public abstract class Unit : ICombatant
    {
        private string name;
        public uint MaxHealth { get; protected set; }
        public uint CurrentHealth { get; protected set; }
        public uint Level { get; protected set; }
        public uint CurrentMana { get; protected set; }
        public uint MaxMana { get; protected set; }
        public bool IsAlive { get; protected set; }

        protected Unit(string name, uint level = 1)
        {
            this.Name = name;
            this.Level = level;
            this.MaxHealth = Level * 100;
            this.CurrentHealth = this.MaxHealth;
            this.IsAlive = true;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid name null or empty value");
                }
                this.name = value;
            }
        }
        public abstract uint AttackPoints { get; }

        public abstract uint DefensePoints(DamageType damageType);

        public abstract AttackLog Attack(ICombatant target);

        public virtual AttackLog Defend(AttackLog attack)
        {
            uint resultingDamage = attack.Damage - this.DefensePoints(attack.DamageType);

            attack.Damage = resultingDamage;

            attack.AttackInformation = String.Format("{0} for {1} {2} damage", this.Name, attack.Damage, attack.DamageType);

            this.TakeDamage(resultingDamage);

            return attack;
        }

        public abstract AttackLog SpecialAttack(ICombatant target);

        public abstract void Update();

        protected void TakeDamage(uint damage)
        {
            this.CurrentHealth -= damage;

            if (this.CurrentHealth <= 0)
            {
                this.IsAlive = false;
            }
        }
    }
}
