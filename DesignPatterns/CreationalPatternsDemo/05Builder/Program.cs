using System;
using System.Collections.Generic;

namespace Builder
{
    public class Program
    {
        public static void Main()
        {
            var superBuilder = new SuperCarBuilder();
            var notSuperBuilder = new NotSoSuperCarBuilder();

            var factory = new CarFactory();
            var builders = new List<CarBuilder> { superBuilder, notSuperBuilder };

            foreach (var b in builders)
            {
                var c = factory.Build(b);
                Console.WriteLine($"The Car requested by " +
                    $"{b.GetType().Name}: " +
                    $"\n--------------------------------------" +
                    $"\nHorse Power: {c.HorsePower}" +
                    $"\nImpressive Feature: {c.MostImpressiveFeature}" +
                    $"\nTop Speed: {c.TopSpeedMPH} mph\n");
            }
        }
    }
}