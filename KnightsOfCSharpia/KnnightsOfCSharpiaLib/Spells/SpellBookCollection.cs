namespace KnnightsOfCSharpiaLib.Spells
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class SpellBookCollection
    {
        private readonly List<Spell> _availableSpells;

        public SpellBookCollection()
        {
            this._availableSpells = new List<Spell>();

            this.SpellBook = this._availableSpells.AsReadOnly();
        }

        public SpellBookCollection(List<Spell> spellsToAdd)
        {
            this._availableSpells = new List<Spell>();
            this._availableSpells.AddRange(spellsToAdd);

            this.SpellBook = this._availableSpells.AsReadOnly();
        }

        public ReadOnlyCollection<Spell> SpellBook { get; private set; }

        public Spell this[string spellName]
        {
            get
            {
                for (int i = 0; i < this.SpellBook.Count; i++)
                {
                    if (spellName.ToLower() == this.SpellBook[i].Name.ToLower())
                    {
                        return this.SpellBook[i];
                    }
                }

                throw new KeyNotFoundException("No such skill found.");
            }
        }

        public void AddSpell(Spell spellToAdd)
        {
            this._availableSpells.Add(spellToAdd);
        }
    }
}
