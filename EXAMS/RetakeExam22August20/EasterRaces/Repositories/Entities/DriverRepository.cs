using EasterRaces.Models.Drivers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository: Repository<IDriver> 
    {
        private readonly ICollection<IDriver> drivers;
        public DriverRepository()
        {
            this.drivers = new List<IDriver>();
        }
    }
}
