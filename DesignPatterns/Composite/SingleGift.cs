using System;

namespace Composite
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, decimal price) 
            : base(name, price)
        {
        }

        public override decimal CalculateTotalPrice()
        {
            Console.WriteLine($"{this.name} with the price {this.price}");

            return this.price;
        }
    }
}
