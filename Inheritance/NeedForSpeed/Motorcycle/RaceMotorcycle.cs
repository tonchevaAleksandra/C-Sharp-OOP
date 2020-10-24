
namespace NeedForSpeed.Motorcycle
{
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
        public override double DefaultFuelConsumption => 8;
    }
}
