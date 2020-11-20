using System;

namespace Facade
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var car = new CarBuilderFacade()
                 .Info
                 .WithType("BMW")
                 .WithColor("Black")
                 .WithNumberOfDoors(5)
                 .Built
                 .InCity("Lepzig ")
                 .AtAdress("GlucklichStrasse  254")
                 .Build();

            Console.WriteLine(car.ToString());

        }
    }
}
