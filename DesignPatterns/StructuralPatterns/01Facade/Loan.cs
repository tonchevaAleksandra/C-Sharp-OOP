using System;

namespace Facade
{
    public class Loan
    {
        public bool HasNoBadLoans(Student c)
        {
            Console.WriteLine("Verify loans for " + c.Name);
            return true;
        }
    }
}