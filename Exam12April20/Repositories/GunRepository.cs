using System;
using System.Linq;
using System.Collections.Generic;

using CounterStrike.Utilities.Messages;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly ICollection<IGun> guns;
        public GunRepository()
        {
            this.guns = new List<IGun>();
        }
        public IReadOnlyCollection<IGun> Models => this.guns.ToList().AsReadOnly();

        public void Add(IGun model)
        {
            if(model==null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }

            this.guns.Add(model);
        }

        public IGun FindByName(string name)
        {

            IGun gun = this.guns.FirstOrDefault(g => g.Name == name);
            return gun;
        }

        public bool Remove(IGun model)
        {
            return this.guns.Remove(model);
        }
    }
}
