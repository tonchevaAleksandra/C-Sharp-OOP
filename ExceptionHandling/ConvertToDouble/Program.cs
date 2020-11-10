using System;

namespace ConvertToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number to be converted to real number!");
            string input = Console.ReadLine();
            try
            {
                double result = Convert.ToDouble(input);
                Console.WriteLine(result);

            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch(OverflowException ofe)
            {
                Console.WriteLine(ofe.Message);
            }
        }
    }
}
