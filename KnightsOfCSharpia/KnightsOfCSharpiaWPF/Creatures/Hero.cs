using KnightsOfCSharpia.Items;
using KnightsOfCSharpia.Spells;

namespace KnightsOfCSharpia
{
    public abstract class Hero : Unit
    {
        private uint currentMana;
        private uint maxMana;
        private uint experience;
        private uint nextLevelExperience;
        private uint strength;
        private uint dexterity;
        private uint intelligence;
        private uint endurance;
        private Equipment equipment;
        // NasC0 - I added a SpellBookCollection to every unit, that holds all their skills
        private SpellBookCollection abilities;

        public Hero(string name, uint  strength, uint dexterity, uint intelligence, uint endurance) : base(name)
        {
            this.equipment = new Equipment();
            this.strength = strength;
            this.dexterity = dexterity;
            this.intelligence = intelligence;
            this.endurance = endurance;
            this.IsAlive = true;
        }

        public uint CurrentMana
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

        public uint MaxMana
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

        public bool IsAlive { get; set; }

        public void EquipItem(Item item)
        {
            
        }

        public void UnEquipItem(Item item)
        {

        }

        public override uint GetAttackPoints()
        {
            return this.strength * 2; //TODO: Add equipped items to attack power
        }
    }
}
