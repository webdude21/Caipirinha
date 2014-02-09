using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightsOfCSharpia
{
    public class Mage : Hero
    {
        private const uint Strength = 4;
        private const uint Dexterity = 8;
        private const uint Intelligence = 16;
        private const uint Endurance = 7;

        public Mage(string name)
            : base(name, Strength, Dexterity, Intelligence, Endurance)
        {
        
        }

        private List<Spell> spellBook;

        public void Cast(Spell spell)
        {
            throw new System.NotImplementedException();
        }
    }
}
