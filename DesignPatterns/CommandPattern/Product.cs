using System;

namespace CommandPattern
{
    public class Product
    {
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public void IncreasePrice(decimal amount)
        {
            this.Price += amount;
            Console.WriteLine($"The price for the {this.Name} has been increased by {amount}$.");
        }

        public void DecreasePrice(decimal amount)
        {
            if (amount < this.Price)
            {
                this.Price -= amount;
                Console.WriteLine($"The price for the {this.Name} has been decreased by {amount}$.");
            }
        }

        public override string ToString()
        {
            return $"Current price for the {this.Name} product is {this.Price:f2}$.";
        }
    }
}
