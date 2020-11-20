
namespace Facade
{
   public class CarAdressBuilder : CarBuilderFacade
    {
        public CarAdressBuilder(Car car)
        {
            this.Car = car;
        }

        public CarAdressBuilder InCity(string city)
        {
            this.Car.City = city;
            return this;
        }

        public CarAdressBuilder AtAdress(string adress)
        {
            this.Car.Adress = adress;
            return this;
        }
    }
}
