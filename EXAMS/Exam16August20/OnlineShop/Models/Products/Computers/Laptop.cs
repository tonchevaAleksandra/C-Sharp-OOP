using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public class Laptop : Computer
    {
        private const double Performance = 10;
        public Laptop(int id, string manufacturer, string model, decimal price)
            : base(id, manufacturer, model, price, Performance)
        {
        }
    }
}
