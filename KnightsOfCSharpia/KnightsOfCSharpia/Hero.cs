using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public Hero(string name, uint  strength, uint dexterity, uint intelligence, uint endurance) : base(name)
        {
            this.equipment = new Equipment();
            this.strength = strength;
            this.dexterity = dexterity;
            this.intelligence = intelligence;
            this.endurance = endurance;
        }

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
