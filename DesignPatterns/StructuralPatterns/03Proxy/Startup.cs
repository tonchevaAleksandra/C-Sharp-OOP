using System;

namespace Proxy
{
    public class Startup
    {
        public static void Main()
        {
            CalculateProxy proxy = new CalculateProxy();

            Console.WriteLine("Calculations");
            Console.WriteLine("-------------");
            Console.WriteLine(Environment.NewLine + "10 + 5 = " + proxy.Add(10, 5));
            Console.WriteLine(Environment.NewLine + "10 - 5 = " + proxy.Subtract(10, 5));
            Console.WriteLine(Environment.NewLine + "10 * 5 = " + proxy.Multiply(10, 5));
            Console.WriteLine(Environment.NewLine + "10 / 5 = " + proxy.Divide(10, 5));
        }
    }
}
