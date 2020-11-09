using System;

namespace SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                int n = int.Parse(Console.ReadLine());
                if (n < 0)
                    throw new ArgumentNullException();
                Console.WriteLine(Math.Sqrt(n));

            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Ivalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
