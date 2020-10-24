
namespace NeedForSpeed.Car
{
    public class Car : Vehicle
    {
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
        public override double DefaultFuelConsumption => 3;
    }
}
