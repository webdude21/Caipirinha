using KnightsOfCSharpiaLib.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsOfCSharpiaLib.Creatures
{
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
