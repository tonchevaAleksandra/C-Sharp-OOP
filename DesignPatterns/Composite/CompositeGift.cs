using System;
using System.Collections.Generic;

using Composite.Contracts;

namespace Composite
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private readonly ICollection<GiftBase> _gifts;
        public CompositeGift(string name, decimal price) 
            : base(name, price)
        {
            this._gifts = new List<GiftBase>();
        }
        public void Add(GiftBase gift)
        {
            this._gifts.Add(gift);
        }


        public void Remove(GiftBase gift)
        {
            this._gifts.Remove(gift);
        }
        public override decimal CalculateTotalPrice()
        {
            decimal ttlPrice = 0;
            Console.WriteLine($"{this.name} contains the following products with prices:");

            foreach (var item in this._gifts)
            {
                ttlPrice += item.CalculateTotalPrice();
            }

            return ttlPrice;
        }
    }
}
