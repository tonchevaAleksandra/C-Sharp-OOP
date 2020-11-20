using System;

namespace Iterator
{
    public class Startup
    {
        public static void Main()
        {
            INewspaper nyp = new NYPaper();
            INewspaper lap = new LAPaper();

            IIterator nypIterator = nyp.CreateIterator();
            IIterator lapIterator = lap.CreateIterator();

            Console.WriteLine("--------   NYPaper");
            PrintReporters(nypIterator);

            Console.WriteLine("--------   LAPaper");
            PrintReporters(lapIterator);
        }

        public static void PrintReporters(IIterator iterator)
        {
            iterator.First();

            while (!iterator.IsDone())
            {
                Console.WriteLine(iterator.Next());
            }
        }
    }
}
