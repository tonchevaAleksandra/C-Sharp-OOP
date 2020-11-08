using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Common;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double INCR_CNSMPT_FULL_BUS = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override string Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption* INCR_CNSMPT_FULL_BUS;

            if (this.FuelQuantity < fuelNeeded)
            {
                string excMsg = string.Format(ExceptionMessages.NotEnoughFuelExceptionMessage, this.GetType().Name);
                throw new InvalidOperationException(excMsg);
            }

            this.FuelQuantity -= fuelNeeded;

            return $"{this.GetType().Name} travelled {distance} km";
        }
        public override string DriveEmpty(double distance)
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

    }
}
