using System;

using EasterRaces.Utilities.Messages;
using EasterRaces.Models.Cars.Contracts;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private const int MinimunSymbolsForModel = 4;
        private string model;
      

        public Car(string model, int horsePower)
        {
            this.Model = model;

            this.HorsePower = horsePower;
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < MinimunSymbolsForModel)
                {
                    string msg = string.Format(ExceptionMessages.InvalidModel, value, MinimunSymbolsForModel);
                    throw new ArgumentException(msg);
                }

                this.model = value;
            }
        }

        public abstract int HorsePower { get; protected set; }
   
    
        public abstract double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            double racePoints = this.CubicCentimeters / this.HorsePower * laps;
            return racePoints;
        }
    }
}
