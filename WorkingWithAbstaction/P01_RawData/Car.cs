
namespace RawData
{
    public class Car
    {
        public string Model { get; }
        public Engine Engine { get; }
        public Cargo Cargo { get; }
        public Tire[] Tires { get; }
        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;

        }

    }
}
