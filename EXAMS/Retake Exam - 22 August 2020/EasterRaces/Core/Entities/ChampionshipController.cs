using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private CarRepository cars;
        private DriverRepository drivers;
        private RaceRepository races;
        public ChampionshipController()
        {
            this.cars = new CarRepository();
            this.drivers = new DriverRepository();
            this.races = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            if (!this.drivers.GetAll().Any(d=>d.Name== driverName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if(!this.cars.GetAll().Any(c=>c.Model==carModel))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            ICar car = this.cars.GetAll().FirstOrDefault(c => c.Model == carModel);
            IDriver driver = this.drivers.GetAll().FirstOrDefault(d => d.Name == driverName);

            driver.AddCar(car);
            string output = string.Format(OutputMessages.CarAdded, driverName, carModel);

            return output;
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if(!this.races.GetAll().Any(r=>r.Name==raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (!this.drivers.GetAll().Any(d => d.Name == driverName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            IRace race = this.races.GetAll().FirstOrDefault(r => r.Name == raceName);
            IDriver driver = this.drivers.GetAll().FirstOrDefault(d => d.Name == driverName);
            race.AddDriver(driver);

            string output = string.Format(OutputMessages.DriverAdded, driverName, raceName);

            return output;

        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if(this.cars.GetAll().Any(c=>c.Model==model))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }
            ICar car = null;
            if(type=="Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if(type=="Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            this.cars.Add(car);

            string output= string.Format(OutputMessages.CarCreated, car.GetType().Name, model);

            return output;
        }

        public string CreateDriver(string driverName)
        {
           if(this.drivers.GetAll().Any(d=>d.Name==driverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName)); 
            }

            this.drivers.Add(new Driver(driverName));

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            if(this.races.GetAll().Any(r=>r.Name==name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);
            this.races.Add(race);

            string output = string.Format(OutputMessages.RaceCreated, name);

            return output;
        }

        public string StartRace(string raceName)
        {
            if (!this.races.GetAll().Any(r => r.Name == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            IRace race = this.races.GetAll().FirstOrDefault(r => r.Name == raceName);
            if (race.Drivers.Count<3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            List<IDriver> driversInRace = race.Drivers.ToList().OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)).Take(3).ToList();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < driversInRace.Count; i++)
            {
                IDriver driver = driversInRace[i];
                if(i==0)
                {
                    sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, driver.Name, raceName));
                }
                else if(i==1)
                {
                    sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, driver.Name, raceName));
                }
                else if(i==2)
                {
                    sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, driver.Name, raceName));
                }

            }
            this.races.Remove(race);
            return sb.ToString().Trim();
        }
    }
}
