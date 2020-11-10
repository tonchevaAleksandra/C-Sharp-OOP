using System;
using CustomException.Exceptions;

namespace CustomException
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Student student = new Student("Dimcho", "Pe7rov", 21, "dim40@abv.bg");
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine($"Exception thrown: {ane.Message}");
            }
            catch (ArgumentOutOfRangeException aor)
            {
                Console.WriteLine($"Exception thrown: {aor.Message}");
            }
            catch (InvalidPersonNameException ipn)
            {
                Console.WriteLine(ipn.Message);
            }
        }
    }
}
