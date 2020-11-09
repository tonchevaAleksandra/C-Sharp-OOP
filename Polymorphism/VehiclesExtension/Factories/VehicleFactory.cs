using System;
using Vehicles.Common;
using Vehicles.Models;

namespace Vehicles.Factories
{
   public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            Vehicle vehicle = null;
            if(type=="Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if(type=="Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if(type=="Bus")
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }
            if(vehicle==null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidtypeExceptionMessage);
            }

            return vehicle;
        }
    }
}
