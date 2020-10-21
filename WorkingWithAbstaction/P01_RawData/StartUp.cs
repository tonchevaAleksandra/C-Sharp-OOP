using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
  public  class RawData
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();
            var lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
               var parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var model = parameters[0];
                var car= CreateCar(parameters, model);
                cars.Add(car);
            }

            var command = Console.ReadLine();
            if (command == "fragile")
            {
                var fragile = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
               var flamable = cars
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }

        private static Car CreateCar(string[] parameters, string model)
        {
            var engine = CreateEngine(parameters);
            var cargo = CreateCargo(parameters);
            var tires = CreateTires(parameters);
           var car = new Car(model, engine, cargo, tires);
            return car;
        }

        private static Tire[] CreateTires(string[] parameters)
        {
            var tire1Pressure = double.Parse(parameters[5]);
            var tire1age = int.Parse(parameters[6]);
            var tire1 = new Tire(tire1Pressure, tire1age);
            var tire2Pressure = double.Parse(parameters[7]);
            var tire2age = int.Parse(parameters[8]);
            var tire2 = new Tire(tire2Pressure, tire2age);
            var tire3Pressure = double.Parse(parameters[9]);
            var tire3age = int.Parse(parameters[10]);
            var tire3 = new Tire(tire3Pressure, tire3age);
            var tire4Pressure = double.Parse(parameters[11]);
            var tire4age = int.Parse(parameters[12]);
            var tire4 = new Tire(tire4Pressure, tire4age);
            var tires = new Tire[] { tire1, tire2, tire3, tire4 };
            return tires;
        }

        private static Cargo CreateCargo(string[] parameters)
        {
            var cargoWeight = int.Parse(parameters[3]);
            var cargoType = parameters[4];
            var cargo = new Cargo(cargoWeight, cargoType);
            return cargo;
        }

        private static Engine CreateEngine(string[] parameters)
        {
            var engineSpeed = int.Parse(parameters[1]);
            var enginePower = int.Parse(parameters[2]);
            var engine = new Engine(engineSpeed, enginePower);
            return engine;
        }
    }
}
