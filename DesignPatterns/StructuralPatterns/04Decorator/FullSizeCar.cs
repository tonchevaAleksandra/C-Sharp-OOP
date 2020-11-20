namespace Decorator
{
    public class FullSizeCar : Car
    {
        public FullSizeCar()
        {
            this.Description = "FullSize Car";
        }

        public override double GetCarPrice() => 30000.00;
      
        public override string GetDescription() => Description;
    }
}
