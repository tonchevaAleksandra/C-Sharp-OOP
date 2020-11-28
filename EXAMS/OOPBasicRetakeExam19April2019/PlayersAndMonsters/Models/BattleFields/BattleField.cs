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
                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
               
            }

            if (enemyPlayer.GetType().Name == nameof(Beginner))
            {
                enemyPlayer.Health += 40;

                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
               
            }

            attackPlayer.Health += attackPlayer.CardRepository.Cards.Select(c => c.HealthPoints).Sum();
            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Select(c => c.HealthPoints).Sum();

            while (true)
            {
                var attackerDamagePoints = attackPlayer.CardRepository.Cards.Select(c => c.DamagePoints).Sum();
                enemyPlayer.TakeDamage(attackerDamagePoints);
                if (enemyPlayer.IsDead)
                {
                    break; 
                }

                var enemyDamagePoints = enemyPlayer.CardRepository.Cards.Select(c => c.DamagePoints).Sum();
                attackPlayer.TakeDamage(enemyDamagePoints);
                if(attackPlayer.IsDead)
                {
                    break;
                }
            }
        }
    }
}
