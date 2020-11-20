using System;

namespace Composite
{
    public class Employee : IEmployee
    {
        public int EmployeeID { get; set; }

        public string Name { get; set; }

        public int Rating { get; set; }

        public void PerformanceSummary()
        {
            Console.WriteLine(
                Environment.NewLine + 
                "Performance summary of employee: " + 
                $"{Name} is {Rating} out of 5");
        }
    }
}