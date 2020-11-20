using System;
using System.Collections.Generic;

namespace Composite
{
    public class Supervisor : IEmployee
    {
        private List<IEmployee> listSubordinates;

        public Supervisor()
        {
            this.listSubordinates = new List<IEmployee>();
        }

        public int EmployeeID { get; set; }

        public string Name { get; set; }

        public int Rating { get; set; }

        public IReadOnlyCollection<IEmployee> ListSubordinates => this.listSubordinates.AsReadOnly();

        public void PerformanceSummary()
        {
            Console.WriteLine("\nPerformance summary of supervisor: " +
                              $"{Name} is {Rating} out of 5");
        }

        public void AddSubordinate(IEmployee employee)
        {
            listSubordinates.Add(employee);
        }
    }
}