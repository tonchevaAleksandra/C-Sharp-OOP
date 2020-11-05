using System;
using System.Collections.Generic;
using System.Text;
using ShoppingSpree.Common;

namespace ShoppingSpree.Models
{
   public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
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
        public decimal Cost 
        {
            get
            {
                return this.cost;
            }
            private set
            {
                CommonValidators.ValidateSum(value);
                this.cost = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
