using System;
using System.Collections.Generic;

namespace Practice
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle airplane = new Airplane();
           
            Vehicle secondVehicle = new Truck();//we have access just to properies of Vehicle, not to Truck
            secondVehicle.Model = "MAN";
            Truck truck = new Truck();
            truck.Model = "MAN";
            truck.MaxLoad = 15;
            object obj = new Truck();// we have access just to properties of object
            Vehicle motor = new Motorcycle();
            var vehicles = new List<IVehicle> { airplane, truck, motor };
            foreach (var item in vehicles)
            {
                PrintVehicleModels(item);
                PrintVrumVrum(item);
            }

            object obj1 = 5;
            //var motorcycle = (Motorcycle)obj1; // System.InvalidCastException: 'Unable to cast object of type 'System.Int32' to type 'Practice.Motorcycle'.'

            var motorcycle = obj1 as Motorcycle;// if obj1 is not a Motorcycle => motorcycle stays null
            Console.WriteLine("Print motorcycle");
            Console.WriteLine(motorcycle==null);//true
            Console.WriteLine(motorcycle);//nothing printed
            var airPl = new Airplane();
            Console.WriteLine(airplane.VrumVrum());
            Console.WriteLine(airPl.VrumVrum(10));
        }
        public static void PrintVrumVrum(IVehicle vehicle)
        {
            Console.WriteLine(vehicle.VrumVrum());
        }
        public static void PrintVehicleModels(IVehicle vehicle)
        {
            Console.WriteLine(vehicle.Model);
        }
    }
}
