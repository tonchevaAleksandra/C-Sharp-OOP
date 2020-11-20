using System;
using System.Collections.Generic;

namespace AbstractFactory
{
    public class Program
    {
        public static void Main()
        {
            List<string> accntNumbers = new List<string> {
                "CITI-456",
                "NATIONAL-987",
                "CHASE-222" };

            for (int i = 0; i < accntNumbers.Count; i++)
            {
                ICreditUnionFactory anAbstractFactory =
                    CreditUnionFactoryProvider.
                        GetCreditUnionFactory(accntNumbers[i]);
                if (anAbstractFactory == null)
                {
                    var accNumber = accntNumbers[i];
                    Console.WriteLine($"Sorry. The account number {accNumber} is invalid.");
                }
                else
                {
                    ILoanAccount loan = anAbstractFactory.CreateLoanAccount();
                    ISavingsAccount savings = anAbstractFactory.CreateSavingsAccount();
                }
            }
        }
    }
}