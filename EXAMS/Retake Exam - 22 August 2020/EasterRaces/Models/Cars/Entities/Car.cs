using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private int minHorsePower;
        private int maxHorsePower;
        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.CubicCentimeters = cubicCentimeters;
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            this.HorsePower = horsePower;
        }
        public string Model
        {
            get => this.model;
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    string emsg = string.Format(ExceptionMessages.InvalidModel, value, 4);
                    throw new ArgumentException(emsg);
                }

                this.model = value;
            }
        }
        public  int HorsePower 
        {
            get => this.horsePower;
            private set
            {
                if(value<this.minHorsePower || value>this.maxHorsePower)
                {
                    string emsg = string.Format(ExceptionMessages.InvalidHorsePower, value);
                    throw new ArgumentException(emsg);
                }

                this.horsePower = value;
            }
        }
        
        public  double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            double racePoints = this.CubicCentimeters / this.HorsePower * laps;
            return racePoints;
        }
    }
}
