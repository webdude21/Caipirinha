using KnnightsOfCSharpiaLib.Common;
using System;

namespace KnnightsOfCSharpiaLib.Creatures
{
    public class Warrior : Hero, IScalable
    {

        public Warrior(string name, uint strenght, uint dexterity, uint intelligence, uint willpower)
            : base(name, strenght, dexterity, intelligence, willpower) { }

        public override uint GetAttackPoints()
        {
            return this.Strength*Level;
        }

        public override uint GetDeffencePoints()
        {
            return this.Dexterity*Level;
        }

        //public override AttackLog Attack(Hero target)
        //{
        //    if (target.IsAlive)
        //    {
        //        var currentAbility = this.Abilities["basic attack"];
        //        this.CurrentMana -= currentAbility.ManaCost;
        //        var attackResult = currentAbility.Effect(this.GetAttackPoints());

        //        string result = target.Defend(attackResult);
        //        return new AttackLog(true, String.Format("{0} uses {1} on {2}", this.Name, currentAbility.Name, result));
        //    }
        //    return AttackLog.AttackFailed;
        //}

        public override string Defend(Spells.SpellDamage attackSpell)
        {
            throw new NotImplementedException();
        }

        public void SpecialAttack()
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

        public int CurrentXp
        {
            get { throw new NotImplementedException(); }
        }

        public int NeededXP
        {
            get { throw new NotImplementedException(); }
        }
    }
}
