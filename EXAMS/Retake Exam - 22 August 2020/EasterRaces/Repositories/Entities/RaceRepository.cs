using EasterRaces.Models.Races.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : Repository<IRace>
    {
        private readonly ICollection<IRace> races;
        public RaceRepository()
        {
            this.races = new List<IRace>();
        }
    }
}
