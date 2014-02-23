using KnightsOfCSharpiaLib.Engine;

namespace KnightsOfCSharpiaLib.Creatures
{
    public class EnemyMage : Creature, ICombatant
    {
        public EnemyMage(string name, uint level, MageType type) : base(name, level)
        {
            this.Type = type.ToString();
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }

        public override uint DefensePoints(DamageType damageType)
        {
            throw new System.NotImplementedException();
        }

        public override AttackLog Attack(ICombatant target)
        {
            throw new System.NotImplementedException();
        }

        public override AttackLog SpecialAttack(ICombatant target)
        {
            throw new System.NotImplementedException();
        }

        public override uint AttackPoints
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
