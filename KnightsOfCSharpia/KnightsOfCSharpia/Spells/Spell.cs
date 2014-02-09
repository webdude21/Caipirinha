using KnightsOfCSharpia.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightsOfCSharpia.Spells
{
    public abstract class Spell
    {

        public Spell(bool affectsEnemy, bool affectsCaster, int manaCost, string name, string description)
        {
            
        }

        public bool AffectsEnemy { get; private set; }

        public bool AffectsCaster { get; private set; }

        public int ManaCost { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public abstract SpellDamage Effect(int casterModifier);
    }
}
