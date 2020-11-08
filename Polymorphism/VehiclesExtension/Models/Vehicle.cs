using System;
using Vehicles.Contracts;
using Vehicles.Common;

namespace Vehicles.Models
{
    public abstract class Vehicle : IDriveable, IRefuelable
    {
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
                
            }
        }
        public virtual double FuelConsumption { get; protected set; }
        public virtual double TankCapacity { get; protected set; }


        public virtual string Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;

            if (this.FuelQuantity < fuelNeeded)
            {
                string excMsg = string.Format(ExceptionMessages.NotEnoughFuelExceptionMessage, this.GetType().Name);
                throw new InvalidOperationException(excMsg);
            }

            this.FuelQuantity -= fuelNeeded;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual string DriveEmpty(double distance)
        {
            return $"{this.GetType().Name} travelled {distance} km";
        }
        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                string excMsg = string.Format(ExceptionMessages.InvalidFuelAmountMessage);
                throw new InvalidOperationException(excMsg);
            }
            else if (this.fuelQuantity + liters > this.TankCapacity)
            {
                string excMsg = string.Format(ExceptionMessages.InvalidRefuelCommandMessage, liters);
                throw new InvalidOperationException(excMsg);
            }
            else
                this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }

    }
}
