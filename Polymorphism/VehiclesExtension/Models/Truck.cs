using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double INCR_CNSMPT = 1.6;
        private const double FUEL_LEAK = 0.05;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            protected set => base.FuelConsumption = value + INCR_CNSMPT;
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters);
            this.FuelQuantity -= (liters * FUEL_LEAK);
        }
    }
}
