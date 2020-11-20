namespace FactoryMethod
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var factory = new SavingsAcctFactory() as ICreditUnionFactory;
            var cityAcct = factory.GetSavingsAccount("CITY-321");
            var nationalAcct = factory.GetSavingsAccount("NATIONAL-987");

            Console.WriteLine($"My citu balance is ${cityAcct.Balance}" +
                $" and national balance is ${nationalAcct.Balance}");
        }
    }
}