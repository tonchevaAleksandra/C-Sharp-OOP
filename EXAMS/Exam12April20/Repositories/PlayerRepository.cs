using System;
using System.Linq;
using System.Collections.Generic;

using CounterStrike.Utilities.Messages;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private ICollection<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models => this.players.ToList().AsReadOnly();
        public void Add(IPlayer model)
        {
            if (model == null)
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);

            this.players.Add(model);
        }

        public IPlayer FindByName(string name)
        {
            IPlayer player = this.players.FirstOrDefault(p => p.Username== name);
            return player;
        }

        public bool Remove(IPlayer model)
        {
            return this.players.Remove(model);
        }
    }
}
