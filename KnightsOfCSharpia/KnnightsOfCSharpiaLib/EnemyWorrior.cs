
using KnnightsOfCSharpiaLib.Common;
using KnnightsOfCSharpiaLib.Creatures;

namespace KnnightsOfCSharpiaLib
{
    public class EnemyWorrior : Creature
    {
        public EnemyWorrior(string name, uint level, WorriorType type) : base(name, level)
        {
            this.Type = type.ToString();
        }

        public override AttackLog Attack(Unit target)
        {
            throw new System.NotImplementedException();
        }

        public override AttackLog Defend(uint damage)
        {
            throw new System.NotImplementedException();
        }

        public override AttackLog SpecialAttack(Unit target)
        {
            throw new System.NotImplementedException();
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
