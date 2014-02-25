namespace KnightsOfCSharpiaLib.Creatures
{
    using KnightsOfCSharpiaLib.Items;

    public abstract class Hero : Unit, IScalable, ICombatant
    {
        protected Hero(string name)
            : base(name)
        {
            this.Equipment = new Equipment();
            this.NeededXP = 100;
            this.CurrentXp = 0;
            this.Inventory = new Inventory();
        }

        public Inventory Inventory { get; protected set; }
        public uint Strength { get; protected set; }
        public uint Dexterity { get; protected set; }
        public uint Intelligence { get; protected set; }
        public uint WillPower { get; protected set; }

        public Equipment Equipment { get; protected set; }

        public uint CurrentXp { get; private set; }

        public uint NeededXP { get; private set; }

        public void EquipItem(Item item)
        {
            if (item == null)
            {
                return;
            }
            this.Equipment.AddItem(item);
            this.Strength += item.StrengthModifier;
            this.Dexterity += item.DexterityModifier;
            this.Intelligence += item.IntelligenceModifier;
            this.WillPower += item.WillPowerModifier;
        }

        public void UnEquipItem(Item item)
        {
            if (item == null)
            {
                return;
            }
            this.Equipment.RemoveItem(item);
            this.Strength -= item.StrengthModifier;
            this.Dexterity -= item.DexterityModifier;
            this.Intelligence -= item.IntelligenceModifier;
            this.WillPower -= item.WillPowerModifier;
        }

        public void AddXP(uint xp)
        {
            this.CurrentXp += xp;
            if (this.CurrentXp > this.NeededXP)
            {
                this.LevelUp();
            }
        }

        public virtual void LevelUp()
        {
            this.Level++;
            this.CurrentXp -= this.NeededXP;
            this.NeededXP = (uint)(this.NeededXP * 1.4);
        }

        public override void Update()
        {
            this.CurrentMana += (int)this.Intelligence * 3;

            if (this.CurrentMana > this.MaxMana)
            {
                this.CurrentMana = (int)this.MaxMana;
            }
        }
    }
}
