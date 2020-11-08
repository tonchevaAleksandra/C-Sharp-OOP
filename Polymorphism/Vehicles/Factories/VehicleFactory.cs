using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Common;
using Vehicles.Models;

namespace Vehicles.Factories
{
   public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption)
        {
            Vehicle vehicle = null;
            if(type=="Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if(type=="Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }
            if(vehicle==null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidtypeExceptionMessage);
            }

            return vehicle;
        }
    }
}
