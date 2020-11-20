using System;

namespace Adapter
{
    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine("Employee list from 3rd party organization system.");
            Console.WriteLine("-------------------------------------------------");
            
            ITarget adapter = new EmployeeAdapter();

            foreach (string employee in adapter.GetEmployees())
            {
                Console.WriteLine(employee);
            }
        }
    }
}