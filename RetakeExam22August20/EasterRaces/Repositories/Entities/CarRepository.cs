
using System.Collections.Generic;

using EasterRaces.Models.Cars.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : Repository<ICar>
    {
        private readonly ICollection<ICar> cars;
        public CarRepository()
        {
            this.cars = new List<ICar>();
        }
    }
}
