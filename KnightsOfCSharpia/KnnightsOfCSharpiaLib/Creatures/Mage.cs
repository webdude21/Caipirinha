using KnightsOfCSharpiaLib.Common;
using KnightsOfCSharpiaLib.Spells;
using System;

namespace KnightsOfCSharpiaLib.Creatures
{
    public class Mage : Hero, IScalable
    {
        public Mage(string name, uint strenght, uint dexterity, uint intelligence, uint willpower)
            : base(name, strenght, dexterity, intelligence, willpower)
        {
            this.MaxMana = intelligence * 100;
            this.MaxHealth = willpower * 100;
        }

        public int CurrentXp { get; private set; }

        public int NeededXP { get; private set; }

        // Returns AttackLog, so we can see if the attack has passed
        // And if it passed, the details about it:
        // What type of damage is dealt, what ability was used, how much damage was dealt
        public override uint GetAttackPoints()
        {
            return this.Intelligence * Level;
        }

        public override uint GetDeffencePoints()
        {
            return this.Willpower * Level;
        }

        public override AttackLog SpecialAttack(Unit target)
        {
            throw new NotImplementedException();
        }

        //public override AttackLog Attack(Hero target)
        //{
        //    if (target.IsAlive)
        //    {
        //        // Here the computer generated oponents can decide what attack to use
        //        // For now it's only basic attack
        //        var spellUsed = this.Abilities["basic attack"];
        //        var spellCastResult = spellUsed.Effect(this.GetAttackPoints());
        //        this.CurrentMana -= spellUsed.ManaCost;

        //        string result = target.Defend(spellCastResult);
        //        return new AttackLog(true, String.Format("{0} uses {1} on {2}", this.Name, spellUsed.Name, result));
        //    }
        //    return AttackLog.AttackFailed;
        //}

        public void Cast(Spell spell)
        {
            throw new System.NotImplementedException();
        }

        public override AttackLog Attack(Unit target)
        {
            throw new NotImplementedException();
        }

        public void LevelUp()
        {
            this.Intelligence = this.Intelligence + 1;
            this.Willpower = this.Willpower + 1;
            this.MaxHealth = this.MaxHealth + 50;
            this.MaxMana = this.MaxMana + 100;
        }

        public override AttackLog Defend(uint damage)
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
