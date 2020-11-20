using System;

namespace Facade
{
    public class Startup
    {
        public static void Main()
        {
            CollegeLoan collegeLoan = new CollegeLoan();

            Student student = new Student("Hunter Sky");
            bool eligible = collegeLoan.IsEligible(student, 75000);

            Console.WriteLine(Environment.NewLine + student.Name +
                " has been " + (eligible ? "Approved" : "Rejected"));
        }
    }
}