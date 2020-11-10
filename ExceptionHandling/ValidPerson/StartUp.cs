using System;

namespace ValidPerson
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Person first = new Person("Pesho", "Petrov", 25);
                Person second = new Person("", "Berov", 15);
                Person third = new Person("Peter", "", 35);
                Person fourth = new Person("Stamo", "stamenov", -20);
                Person fifth = new Person("Sasho", "stoyanov", 125);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine($"Exception thrown: {ane.Message}");
            }
            catch(ArgumentOutOfRangeException aor)
            {
                Console.WriteLine($"Exception thrown: {aor.Message}");
            }
        }
    }
}
