using KnightsOfCSharpia.Common;
using KnightsOfCSharpia.Spells;
using System;

namespace KnightsOfCSharpia.Creatures
{
    public abstract class Unit
    {
        private string name;
        public uint MaxHealth { get; set; }
        public uint CurrentHealth { get; set; }
        public uint Level { get; set; }

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

        public abstract uint GetAttackPoints();
        public abstract uint GetDeffencePoints();

        public abstract AttackLog Attack(Hero target);

        public abstract string Defend(SpellDamage attackSpell);

        public virtual void Update()
        {
            
        }
    }
}
