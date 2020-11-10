﻿using System;

namespace EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int start = 1;
            int end = 90;
        
            for (int i = 1; i <= 10; i++)
            {              
                start = ReadNumbers(start, end);
                
                end++;
            }
        }
        /// <summary>
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"> End can be end + (10-i) < 100</param>
        /// <returns></returns>
        private static int ReadNumbers(int start, int end)
        {
            int num = 0;
            try
            {
                Console.WriteLine($"Enter number such that {start} < your number < {end}!");
                num = int.Parse(Console.ReadLine());
                if(!(start<num && num<end))
                {
                    while (!(start < num && num < end))
                    {
                        Console.WriteLine($"Your number is not in range {start} - {end}!");
                        Console.WriteLine($"Enter number such that {start} < your number < {end}!");
                        num = int.Parse(Console.ReadLine());
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number!");
            }

            return num;
        }
    }
}
