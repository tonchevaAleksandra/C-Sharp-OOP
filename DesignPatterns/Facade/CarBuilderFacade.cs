
namespace Facade
{
   public class CarBuilderFacade
    {
        protected Car Car { get; set; }

        public CarBuilderFacade()
        {
            this.Car = new Car();
        }

        public Car Build() => this.Car;

        public CarInfoBuilder Info => new CarInfoBuilder(this.Car);

        public CarAdressBuilder Built => new CarAdressBuilder(Car);
    }
}
