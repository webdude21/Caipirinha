﻿using KnnightsOfCSharpiaLib.Common;
using System;

namespace KnnightsOfCSharpiaLib.Creatures
{
    public class Warrior : Hero, IScalable
    {
        public Warrior(string name, uint strenght, uint dexterity, uint intelligence, uint willpower)
            : base(name, strenght, dexterity, intelligence, willpower)
        {
            this.MaxMana = intelligence * 100;
            this.MaxHealth = willpower * 100;
        }

        public override uint GetAttackPoints()
        {
            return this.Strength * Level;
        }

        public override uint GetDeffencePoints()
        {
            return this.Dexterity * Level;
        }

        public override AttackLog SpecialAttack(Unit target)
        {
            throw new NotImplementedException();
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

        public override AttackLog Defend(uint damage)
        {
            throw new NotImplementedException();
        }

        public override AttackLog Attack(Unit target)
        {
            throw new NotImplementedException();
        }

        public void LevelUp()
        {
            this.Strength = this.Strength + 1;
            this.Dexterity = this.Dexterity + 1;
            this.MaxHealth = this.MaxHealth + 100;
            this.MaxMana = this.MaxMana + 50;
        }

        public int CurrentXp
        {
            get { throw new NotImplementedException(); }
        }

        public int NeededXP
        {
            get { throw new NotImplementedException(); }
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
