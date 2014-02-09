using KnightsOfCSharpia.Common;
using KnightsOfCSharpia.Items;
using KnightsOfCSharpia.Spells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightsOfCSharpia.Creatures
{
    public abstract class Creature
    {
        private string name;
        private int maxHp;
        private int maxMana;
        private int currentHP;
        private int currentMana;
        private int level;
        private int nextLevel;
        private int exp;
        private int str;
        private int dex;
        private int intelligence;
        private int endurence;
        private int attackPoints;
        private int deffencePoints;
        // NasC0 - I added a SpellBookCollection to every creature, that holds all their skills
        private SpellBookCollection abilities;
        private bool isAlive;

        public static class Inventory
        {
            private static int capacity;
            private static int usedCapacity;
            private static List<Item> items;
        }

        public static class Equipment
        {

        }

        public string Name 
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public int CurrentMana
        {
            get
            {
                return this.currentMana;
            }
            set
            {
                this.currentMana = value;
            }
        }

        public int CurrentHP
        {
            get
            {
                return this.currentHP;
            }
            set
            {
                this.currentHP = value;
            }
        }

        public int MaxMana
        {
            get
            {
                return this.maxMana;
            }
            set
            {
                this.maxMana = value;
            }
        }

        public int MaxHp
        {
            get
            {
                return this.maxHp;
            }
            set
            {
                this.maxHp = value;
            }
        }

        public int DeffencePoints
        {
            get
            {
                return this.deffencePoints;
            }
            set
            {
                this.deffencePoints = value;
            }
        }

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            set
            {
                this.attackPoints = value;
            }
        }

        public int Endurence
        {
            get
            {
                return this.endurence;
            }
            set
            {
                this.endurence = value;
            }
        }

        public int Intelligence
        {
            get
            {
                return this.intelligence;
            }
            set
            {
                this.intelligence = value;
            }
        }

        public int Dex
        {
            get
            {
                return this.dex;
            }
            set
            {
                this.dex = value;
            }
        }

        public int Str
        {
            get
            {
                return this.str;
            }
            set
            {
                this.str = value;
            }
        }

        public int Exp
        {
            get
            {
                return this.exp;
            }
            set
            {
                this.exp = value;
            }
        }

        public int NextLevel
        {
            get
            {
                return this.nextLevel;
            }
            set
            {
                this.nextLevel = value;
            }
        }

        public int Level
        {
            get
            {
                return this.level;
            }
            set
            {
                this.level = value;
            }
        }

        public SpellBookCollection Abilities
        {
            get
            {
                return this.abilities;
            }
            private set
            {
                this.abilities = value;
            }
        }

        public bool IsAlive
        {
            get
            {
                return this.isAlive;
            }
            private set
            {
                this.isAlive = value;
            }
        }

        // NasC0 - i changed these methods to abstract, so they can be easily modified from the children.
        public abstract AttackLog Attack(Creature target);

        public abstract string Deffend(SpellDamage attackSpell);
    }
}
