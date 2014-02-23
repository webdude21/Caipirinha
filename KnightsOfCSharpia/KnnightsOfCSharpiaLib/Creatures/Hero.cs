using KnightsOfCSharpiaLib.Items;

namespace KnightsOfCSharpiaLib.Creatures
{
    public abstract class Hero : Unit, IScalable, ICombatant
    {
        public uint Strength { get; protected set; }
        public uint Dexterity { get; protected set; }
        public uint Intelligence { get; protected set; }
        public uint WillPower { get; protected set; }

        public Equipment Equipment { get; private set; }

        protected Hero(string name)
            : base(name)
        {
            this.Equipment = new Equipment();
            this.NeededXP = 100;
            this.CurrentXp = 0;
        }

        public uint CurrentXp { get; private set; }

        public uint NeededXP { get; private set; }

        public void EquipItem(Item item)
        {
            this.Equipment.AddItem(item);
            this.Strength += item.StrengthModifier;
            this.Dexterity += item.DexterityModifier;
            this.Intelligence += item.IntelligenceModifier;
            this.WillPower += item.WillPowerModifier;
        }

        public void UnEquipItem(Item item)
        {
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
    }
}

