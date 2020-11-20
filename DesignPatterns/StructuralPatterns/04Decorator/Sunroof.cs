namespace Decorator
{
    public class Sunroof : CarDecorator
    {
        public Sunroof(Car car)
            : base(car)
        {
            this.Description = "Sunroof";
        }

        public override string GetDescription() => $"{car.GetDescription()}, {Description}";

        public override double GetCarPrice() => car.GetCarPrice() + 2500;
    }
}
