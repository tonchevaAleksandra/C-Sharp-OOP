using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private const int MinNameLength = 5;
        private const int MinLaps = 1;

        private string name;
        private int laps;

        private readonly List<IDriver> drivers;

        private Race()
        {
            this.drivers = new List<IDriver>();
        }
        public Race(string name, int laps)
            : this()
        {
            this.Name = name;
            this.Laps = laps;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MinNameLength)
                {
                    string msg = string.Format(ExceptionMessages.InvalidName, value, MinNameLength);
                    throw new ArgumentException(msg);
                }
                this.name = value;
            }
        }

        public int Laps
        {
            get
            {
                return this.laps;
            }
            private set
            {
                if (value < MinLaps)
                {
                    string msg = string.Format(ExceptionMessages.InvalidNumberOfLaps, MinLaps);
                    throw new ArgumentException(msg);
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => this.drivers;

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }
            if (!driver.CanParticipate)
            {
                string msg = string.Format(ExceptionMessages.DriverNotParticipate, driver.Name);
                throw new ArgumentException(msg);
            }
            if (this.Drivers.Contains(driver))
            {
                string msg = string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name);
                throw new ArgumentNullException(msg);
            }

            this.drivers.Add(driver);
        }
    }
}
