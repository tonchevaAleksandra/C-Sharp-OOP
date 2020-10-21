using System;

namespace HotelReservation
{
  public  class StartUp
    {
        static void Main(string[] args)
        {
            var info = Console.ReadLine().Split();
            var pricePerDay = decimal.Parse(info[0]);
            var days = int.Parse(info[1]);
           var season=  Enum.Parse<Season>(info[2]);
            var discount = Enum.Parse < Discount > ("None");
           if(info.Length==4)
            {
                discount = Enum.Parse < Discount > (info[3]);
            }

            var calculator = new PriceCalculator();
            var totalPrice=calculator.Calculate(pricePerDay, days, season, discount);
            Console.WriteLine($"{totalPrice:f2}");

        }
    }
}
