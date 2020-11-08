using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double INCR_CNSMPT = 1.6;
        private const double FUEL_LEAK = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }
        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            protected set => base.FuelConsumption = value + INCR_CNSMPT;
        }
        public override void Refuel(double liters)
        {
            base.Refuel(liters * FUEL_LEAK);
        }
    }
}
