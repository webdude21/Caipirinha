using KnightsOfCSharpiaLib.Items;

namespace KnightsOfCSharpiaLib.Creatures
{
    public abstract class Hero : Unit
    {
        public uint Strength { get; set; }
        public uint Dexterity { get; set; }
        public uint Intelligence { get; set; }
        public uint Willpower { get; set; }

        public Inventory Inventory { get; private set; }
        public Equipment Equipment { get; private set; }
        // NasC0 - I added a SpellBookCollection to every unit, that holds all their skills

        protected Hero(string name, uint strength, uint dexterity, uint intelligence, uint willpower)
            : base(name)
        {
            Inventory = new Inventory();
            this.Strength = strength;
            this.Dexterity = dexterity;
            this.Intelligence = intelligence;
            this.Willpower = willpower;
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
    }
}

