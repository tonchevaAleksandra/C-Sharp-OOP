using System;

namespace Fixing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] weekDays = new string[5] 
            { 
                "Sunday",
                "Monday", 
                "Tuesday", 
                "Wednesday",
                "Thursday" 
            };
            try
            {
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine(weekDays[i]);
                }
            }
            catch (IndexOutOfRangeException ior)
            {
                Console.WriteLine(ior.Message);
            }
        }
    }
}
