namespace KnightsOfCSharpiaLib.Engine
{
    using System;
    using KnightsOfCSharpiaLib.Creatures;
    using KnightsOfCSharpiaLib.Exceptions;
    using KnightsOfCSharpiaLib.Common;    

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

        /// <summary>
        /// Initiates the next skirmish and returns the result of fight in a string representation.
        /// </summary>
        /// <param name="desiredAttack">Specifies the type of attack the player selected. If no attack is specified, and it's the player's turn, throws an exception.</param>
        /// <returns>String specifying the result of the attack or throws an exception if it's the player's turn and invalid attack parameter is passed in.</returns>
        public string NextAttack(string desiredAttack = null)
        {
            if ((this.PlayerToon.IsAlive && this.EnemyToon.IsAlive) == false)
            {
                throw new CombatantsDeadException();
            }

            string attackResult = string.Empty;
            if (this.playerTurn)
            {
                if (string.IsNullOrWhiteSpace(desiredAttack))
                {
                    throw new ArgumentException("Invalid parameter passed in!");
                }

                switch (desiredAttack)
                {
                    case "special":
                        try
                        {
                            attackResult = PlayerToon.SpecialAttack(EnemyToon).AttackInformation;
                        }
                        catch (InsufficientManaException ex)
                        {
                            throw ex;
                        }
                        break;
                    case "basic":
                        attackResult = PlayerToon.Attack(EnemyToon).AttackInformation;
                        break;
                    default:
                        break;
                }

                this.playerTurn = false;
            }
            else if (!this.playerTurn)
            {
                int attackChance = RandomGenerator.GetRandomValue(0, 101);

                if (attackChance <= 50)
                {
                    attackResult = EnemyToon.Attack(PlayerToon).AttackInformation;
                }
                else
                {
                    try
                    {
                        attackResult = EnemyToon.SpecialAttack(PlayerToon).AttackInformation;
                    }
                    catch (InsufficientManaException)
                    {
                        attackResult = EnemyToon.Attack(PlayerToon).AttackInformation;
                    }
                }

                this.playerTurn = true;
                
                this.PlayerToon.Update();
                this.EnemyToon.Update();
            }

            return attackResult;
        }
    }
}
