namespace KnightsOfCSharpiaLib.Engine
{
    using System;
    using KnightsOfCSharpiaLib.Creatures;
    using KnightsOfCSharpiaLib.Exceptions;    

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

            return string.Empty;
        }
    }
}