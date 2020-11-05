using System;
using System.Collections.Generic;
using System.Text;
using ShoppingSpree.Common;
using ShoppingSpree.Models;

namespace ShoppingSpree.Models
{
   public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        private Person()
        {
            this.bag = new List<Product>();
        }
        public Person(string name, decimal money)
            :this()
        {
            this.Name = name;
            this.Money = money;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                CommonValidators.ValidateName(value);
                this.name = value;
            }
        }
        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                CommonValidators.ValidateSum(value);
                this.money = value;
            }
        }

        public IReadOnlyList<Product> Bag => this.bag.AsReadOnly();

        public void BuyProduct(Product product)
        {
            if(this.Money<product.Cost)
            {
                throw new InvalidOperationException($"{ this.Name } can't afford {product.Name}");
            }
            this.Money -= product.Cost;
            this.bag.Add(product);
        }

        public override string ToString()
        {
            string productOutPut = this.bag.Count > 0 ? String.Join(", ", this.Bag) : "Nothing bought";
            return $"{this.Name} - {productOutPut}";
        }
    }
}
