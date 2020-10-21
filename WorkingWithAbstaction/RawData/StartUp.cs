using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
  public  class RawData
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = parameters[0];
                Car car = CreateCar(parameters, model);
                cars.Add(car);
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }

        private static Car CreateCar(string[] parameters, string model)
        {
            Engine engine = CreateEngine(parameters);
            Cargo cargo = CreateCargo(parameters);
            Tire[] tires = CreateTires(parameters);
            Car car = new Car(model, engine, cargo, tires);
            return car;
        }

        private static Tire[] CreateTires(string[] parameters)
        {
            double tire1Pressure = double.Parse(parameters[5]);
            int tire1age = int.Parse(parameters[6]);
            Tire tire1 = new Tire(tire1Pressure, tire1age);
            double tire2Pressure = double.Parse(parameters[7]);
            int tire2age = int.Parse(parameters[8]);
            Tire tire2 = new Tire(tire2Pressure, tire2age);
            double tire3Pressure = double.Parse(parameters[9]);
            int tire3age = int.Parse(parameters[10]);
            Tire tire3 = new Tire(tire3Pressure, tire3age);
            double tire4Pressure = double.Parse(parameters[11]);
            int tire4age = int.Parse(parameters[12]);
            Tire tire4 = new Tire(tire4Pressure, tire4age);
            Tire[] tires = new Tire[] { tire1, tire2, tire3, tire4 };
            return tires;
        }

        private static Cargo CreateCargo(string[] parameters)
        {
            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];
            Cargo cargo = new Cargo(cargoWeight, cargoType);
            return cargo;
        }

        private static Engine CreateEngine(string[] parameters)
        {
            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            Engine engine = new Engine(engineSpeed, enginePower);
            return engine;
        }
    }
}
