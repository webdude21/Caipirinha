using System;
using KnightsOfCSharpia.Items;
using KnightsOfCSharpia.Spells;
using KnightsOfCSharpia.Common;

namespace KnightsOfCSharpia.Creatures
{
    public abstract class Unit
    {
        private string name;
        private uint currentHealth;
        private uint maxHealth;
        private uint level;
        private uint defencePoints;
        private Inventory inventory;

        public Unit(string name)
        {
            this.Name = name;
            inventory = new Inventory();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid name null or empty value");
                }

                this.name = value;
            }
        }

        public uint CurrentHealth
        {
            get { return this.currentHealth; }
            protected set { this.currentHealth = value; }
        }

        public uint MaxHealth
        {
            get { return this.currentHealth; }
            protected set { this.currentHealth = value; }
        }

        public uint Level
        {
            get { return this.level; }
            protected set { this.level = value; }
        }

        public abstract uint GetAttackPoints();

        public uint DefencePoints
        {
            get { return this.defencePoints; }
            protected set { this.defencePoints = value; }
        }

        public Inventory Inventory
        {
            get { return this.inventory; }
            protected set { this.inventory = value; }
        }

        public abstract AttackLog Attack(Hero target);

        public abstract string Defend(SpellDamage attackSpell);
    }
}
