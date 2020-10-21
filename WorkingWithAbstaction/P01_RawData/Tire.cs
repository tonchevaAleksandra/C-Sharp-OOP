
namespace RawData
{
   public class Tire
    {
        public double Pressure { get; }
        public int Age { get; }
        public Tire(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }
    }
}
