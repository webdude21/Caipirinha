
using KnnightsOfCSharpiaLib.Creatures;

namespace KnnightsOfCSharpiaLib
{
    public class EnemyWorrior : Creature
    {
        public EnemyWorrior(string name, uint level, WorriorType type) : base(name, level)
        {
            this.Type = type.ToString();
        }
    }
}
