using System;
using System.Linq;

using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.BattleFields.Contracts;

using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException(ExceptionMessages.DeadPlayer);
            }

            if (attackPlayer.GetType().Name == nameof(Beginner))
            {
                attackPlayer.Health += 40;
                attackPlayer.CardRepository.Cards.Select(c => c.DamagePoints += 30);
            }

            if (enemyPlayer.GetType().Name == nameof(Beginner))
            {
                enemyPlayer.Health += 40;
                enemyPlayer.CardRepository.Cards.Select(c => c.DamagePoints += 30);
            }

            attackPlayer.Health += attackPlayer.CardRepository.Cards.Select(c => c.HealthPoints).Sum();
            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Select(c => c.HealthPoints).Sum();

            while (!attackPlayer.IsDead && !enemyPlayer.IsDead)
            {
                enemyPlayer.TakeDamage(attackPlayer.CardRepository.Cards.Sum(c => c.DamagePoints));
                if (!enemyPlayer.IsDead)
                {
                    attackPlayer.TakeDamage(enemyPlayer.CardRepository.Cards.Sum(c => c.DamagePoints));
                }
            }
        }
    }
}
