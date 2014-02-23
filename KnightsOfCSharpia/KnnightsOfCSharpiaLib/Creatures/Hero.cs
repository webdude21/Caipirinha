using KnightsOfCSharpia.Items;
using KnightsOfCSharpia.Spells;

namespace KnightsOfCSharpia.Creatures
{
    public abstract class Hero : Unit
    {
        public uint Strength { get; set; }
        public uint Dexterity { get; set; }
        public uint Intelligence { get; set; }
        public uint Willpower { get; set; }
        public uint CurrentMana { get; set; }
        public uint MaxMana { get; set; }
        public bool IsAlive { get; set; }
        public SpellBookCollection Abilities { get; set; }
        public Equipment Equipment { get; private set; }
        // NasC0 - I added a SpellBookCollection to every unit, that holds all their skills

        protected Hero(string name, uint strength, uint dexterity, uint intelligence, uint willpower)
            : base(name)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
            Willpower = willpower;
            this.Equipment = new Equipment();
        }

        public void EquipItem(Item item)
        {
            this.Equipment.AddItem(item);
        }

        public void UnEquipItem(Item item)
        {
            this.Equipment.RemoveItem(item);
        }

        public override uint GetAttackPoints()
        {
            return this.Strength * 2; //TODO: Add equipped items to attack power
        }

        protected virtual void LevelUp()
        {

        }
    }
}

