namespace KnightsOfCSharpiaLib.Creatures
{
    using KnightsOfCSharpiaLib.Engine;

    public interface ICombatant
    {
        bool IsAlive { get; }

        uint AttackPoints { get; }

        uint DefensePoints(DamageType damageType);

        AttackLog Attack(ICombatant target);

        AttackLog SpecialAttack(ICombatant target);

        AttackLog Defend(AttackLog attack);
    }
}