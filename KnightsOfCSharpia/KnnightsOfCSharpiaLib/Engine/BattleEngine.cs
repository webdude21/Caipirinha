namespace KnightsOfCSharpiaLib.Engine
{
    using KnightsOfCSharpiaLib.Creatures;
    using KnightsOfCSharpiaLib.Exceptions;
    using System;

    public class BattleEngine
    {
        private bool playerTurn;

        public BattleEngine(ICombatant playerToon, ICombatant enemyToon)
        {
            this.PlayerToon = playerToon;
            this.EnemyToon = enemyToon;
            this.playerTurn = true;
        }

        public ICombatant PlayerToon { get; private set; }

        public ICombatant EnemyToon { get; private set; }

        public string NextAttack()
        {
            if ((this.PlayerToon.IsAlive && this.EnemyToon.IsAlive) == false)
            {
                throw new CombatantsDeadException();
            }

            // TODO: Implement attack logic and figure out a way for the user to input the desired attack type.

            return string.Empty;
        }
    }
}
