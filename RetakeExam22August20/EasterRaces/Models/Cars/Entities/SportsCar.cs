
using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double CCentimeters = 3000;
        private const int MinHP = 250;
        private const int MaxHP = 450;

      
        private int horsePower;

        public SportsCar(string model, int horsePower) 
            : base(model, horsePower)
        {
            //this.Model = model;
            //this.HorsePower = horsePower;
            this.CubicCentimeters = CCentimeters;
        }

        public override double CubicCentimeters { get; }
        public override int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            protected set
            {
                if (value < MinHP || value > MaxHP)
                {
                    string msg = string.Format(ExceptionMessages.InvalidHorsePower, value);
                    throw new ArgumentException(msg);
                }

                this.horsePower = value;
            }
        }
    }
}
