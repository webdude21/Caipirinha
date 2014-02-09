using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightsOfCSharpia
{
    public class Warrior : Hero
    {
        private const uint Strength = 15;
        private const uint Dexterity = 6;
        private const uint Intelligence = 2;
        private const uint Endurance = 12;

        public Warrior(string name)
            : base(name, Strength, Dexterity, Intelligence, Endurance)
        {
        
        }

        public void SpecialAttack()
        {
            throw new System.NotImplementedException();
        }
    }
}
