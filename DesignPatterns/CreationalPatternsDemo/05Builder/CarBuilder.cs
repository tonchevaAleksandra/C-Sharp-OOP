namespace Builder
{
    public abstract class CarBuilder
    {
        protected readonly Car car = new Car();

        public abstract void SetHorsePower();
       
        public abstract void SetTopSpeed();
        
        public abstract void SetImpressiveFeature();

        public virtual Car GetCar()
        {
            return car;
        }
    }
}