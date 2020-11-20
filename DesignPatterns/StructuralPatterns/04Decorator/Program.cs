using System;

namespace Decorator
{
    public class Program
    {
        public static void Main()
        {
            Car compactCar = new CompactCar();
            compactCar = new Navigation(compactCar);
            compactCar = new Sunroof(compactCar);
            compactCar = new LeatherSeats(compactCar);

            Console.WriteLine(compactCar.GetDescription());
            Console.WriteLine($"{compactCar.GetCarPrice():C2}");
        }
    }
}
