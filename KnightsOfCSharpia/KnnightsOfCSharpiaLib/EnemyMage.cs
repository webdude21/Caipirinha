using KnnightsOfCSharpiaLib.Creatures;

namespace KnnightsOfCSharpiaLib
{
    public class EnemyMage : Creature
    {
        public EnemyMage(string name, uint level, MageTypes type) : base(name, level)
        {
            this.Type = type.ToString();
        }
    }
}
