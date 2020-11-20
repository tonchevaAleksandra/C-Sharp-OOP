using CommandPattern.Contracts;
using System;

namespace CommandPattern
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var modifyPrice = new ModifyPrice();
            var product = new Product("IPhone 12", 3899.99M);

            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Decrease, 200.00M));
            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 100.00M));
            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Decrease, 3000.00M));

            Console.WriteLine($"I can buy just \n{product}");
        }

        private static void Execute(Product product, ModifyPrice modifyPrice, ICommand command)
        {
            modifyPrice.SetCommamd(command);
            modifyPrice.Invoke();
        }
    }
}
