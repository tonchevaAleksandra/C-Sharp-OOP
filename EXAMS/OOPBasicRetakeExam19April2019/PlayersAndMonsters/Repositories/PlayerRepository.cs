using System;
using System.Linq;
using System.Collections.Generic;

using PlayersAndMonsters.Common;
using PlayersAndMonsters.Repositories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ICollection<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }
        public int Count => this.Players.Count;

        public IReadOnlyCollection<IPlayer> Players => this.players.ToList().AsReadOnly();

        public void Add(IPlayer player)
        {
            CheckIfPlayerExist(player);
            if (this.Players.Any(p => p.Username == player.Username))
            {
                string excMsg = string.Format(ExceptionMessages.PlayerAlreadyExist, player.Username);
                throw new ArgumentException(excMsg);
            }

            this.players.Add(player);
        }


        public IPlayer Find(string username)
        {
            IPlayer player = this.players.FirstOrDefault(p => p.Username == username);
            return player;
        }

        public bool Remove(IPlayer player)
        {
            CheckIfPlayerExist(player);

            return this.players.Remove(player);

        }
        private static void CheckIfPlayerExist(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.PlayerCannotBeNull);
            }
        }
    }
}
