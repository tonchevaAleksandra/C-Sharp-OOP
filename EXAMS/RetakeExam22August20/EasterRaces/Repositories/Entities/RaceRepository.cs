using EasterRaces.Models.Races.Contracts;

using System.Collections.Generic;


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
