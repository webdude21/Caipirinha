using KnnightsOfCSharpiaLib.Common;
using System;

namespace KnnightsOfCSharpiaLib.Creatures
{
    public abstract class Unit
    {
        private string name;
        public uint MaxHealth { get; set; }
        public uint CurrentHealth { get; set; }
        public uint Level { get; set; }
        public uint CurrentMana { get; set; }
        public uint MaxMana { get; set; }
        public bool IsAlive { get; set; }

        protected Unit(string name, uint level = 1)
        {
            this.Name = name;
            this.Level = level;
            this.MaxHealth = Level * 100;
            this.CurrentHealth = this.MaxHealth;
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

        public abstract AttackLog Attack(Unit target);

        public abstract AttackLog Defend(uint damage);

        public abstract uint GetAttackPoints();
        public abstract uint GetDeffencePoints();

        public abstract AttackLog SpecialAttack(Unit target);

        public abstract void Update();
    }
}
