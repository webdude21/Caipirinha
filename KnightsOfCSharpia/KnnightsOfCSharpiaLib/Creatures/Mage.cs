using KnnightsOfCSharpiaLib.Common;
using KnnightsOfCSharpiaLib.Spells;
using System;

namespace KnnightsOfCSharpiaLib.Creatures
{
    public class Mage : Hero, IScalable
    {
        public Mage(string name, uint strenght, uint dexterity, uint Intelligence, uint willpower)
            : base(name, strenght, dexterity, Intelligence, willpower)
        {
        }

        public int CurrentXp { get; private set; }

        public int NeededXP { get; private set; }

        // Returns AttackLog, so we can see if the attack has passed
        // And if it passed, the details about it:
        // What type of damage is dealt, what ability was used, how much damage was dealt
        public override uint GetDeffencePoints()
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

        public override AttackLog Attack(Hero target)
        {
            throw new NotImplementedException();
        }

        public void LevelUp()
        {
            throw new NotImplementedException();
        }

        public override string Defend(Spells.SpellDamage attackSpell)
        {
            throw new NotImplementedException();
        }
    }
}
