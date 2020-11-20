namespace Decorator
{
    public class CarDecorator : Car
    {
        protected Car car;
       
        public CarDecorator(Car car)
        {
            this.car = car;
        }

        public override double GetCarPrice() => car.GetCarPrice();

        public override string GetDescription() => car.GetDescription();
    }
}
