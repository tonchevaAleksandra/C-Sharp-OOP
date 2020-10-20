using System;

namespace rhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                PrintRow(n, i);
            }
            for (int i = n - 1; i >= 1; i--)
            {
                PrintRow(n, i);
            }
        }

        static void PrintRow(int size, int countStars)
        {
            for (int i = 0; i < size - countStars; i++)
            {
                Console.Write(" ");
            }
            for (int j = 0; j < countStars; j++)
            {
                Console.Write("* ");
            }

            Console.WriteLine();

        }
    }
}
