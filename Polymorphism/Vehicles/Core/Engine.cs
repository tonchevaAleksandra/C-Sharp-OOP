
using System;
using System.Collections.Generic;
using System.Linq;
using Vehicles.Factories;
using Vehicles.IO.Contracts;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine
    {
        private readonly IReadable reader;
        private readonly IWritable writer;

        private VehicleFactory vehicleFactory;
        public Engine(IReadable reader, IWritable writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = new VehicleFactory();
        }
        public void Run()
        {

            Vehicle car = CreateVehicle();

            Vehicle truck = CreateVehicle();

            int lines = int.Parse(this.reader.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] cmdArgs = this.reader.ReadLine()
                    .Split()
                    .ToArray();
                try
                {
                    ProcessCommand(car, truck, cmdArgs);
                }
                catch (InvalidOperationException msg)
                {
                    this.writer.WriteLine(msg.Message);
                }
            }

            this.writer.WriteLine(car.ToString());
            this.writer.WriteLine(truck.ToString());
        }

        private void ProcessCommand(Vehicle car, Vehicle truck, string[] cmdArgs)
        {
            string command = cmdArgs[0];
            string vehicleType = cmdArgs[1];
            double arg = double.Parse(cmdArgs[2]);

            switch (command)
            {
                case "Drive":

                    switch (vehicleType)
                    {
                        case "Car":
                            this.writer.WriteLine(car.Drive(arg));
                            break;
                        case "Truck":
                            this.writer.WriteLine(truck.Drive(arg));
                            break;
                        default:
                            break;
                    }
                    break;
                case "Refuel":
                    switch (vehicleType)
                    {
                        case "Car":
                            car.Refuel(arg);
                            break;
                        case "Truck":
                            truck.Refuel(arg);
                            break;
                        default:
                            break;
                    }
                    break;

            }
        }

        private Vehicle CreateVehicle()
        {
            string[] vehicleArgs = this.reader.ReadLine()
                 .Split()
                 .ToArray();
            string type = vehicleArgs[0];
            double fuelQuantity = double.Parse(vehicleArgs[1]);
            double fuelConsumption = double.Parse(vehicleArgs[2]);
            return this.vehicleFactory.CreateVehicle(type, fuelQuantity, fuelConsumption);
        }


    }
}
