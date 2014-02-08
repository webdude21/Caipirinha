using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightsOfCSharpia
{
    public abstract class Creature
    {
        private string name;
        private int hp;
        private int mana;
        private int level;
        private int nextLevel;
        private int exp;
        private int str;
        private int dex;
        private int intelligence;
        private int endurence;
        private int attackPoints;
        private int deffencePoints;

        public static class Inventory
        {

            private static int capacity;
            private static int usedCapacity;
            private static List<Item> items;
        }

        public static class Equipment
        {

        }

        public void Attack()
        {
            throw new System.NotImplementedException();
        }

        public void Deffend()
        {
            throw new System.NotImplementedException();
        }
    }
}
