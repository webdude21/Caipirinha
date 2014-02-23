using KnnightsOfCSharpiaLib.Common;
using KnnightsOfCSharpiaLib.Creatures;

namespace KnnightsOfCSharpiaLib.Creatures
{
    public class EnemyMage : Creature
    {
        public EnemyMage(string name, uint level, MageType type) : base(name, level)
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
