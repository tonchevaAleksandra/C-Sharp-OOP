using System;
using System.Collections.Generic;

namespace Visitor
{
    public class Employees
    {
        private List<Employee> employees;

        public Employees()
        {
            this.employees = new List<Employee>();
        }

        public void Attach(Employee employee)
        {
            this.employees.Add(employee);
        }

        public void Detach(Employee employee)
        {
            this.employees.Remove(employee);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (Employee e in this.employees)
            {
                e.Accept(visitor);
            }

            Console.WriteLine();
        }
    }
}