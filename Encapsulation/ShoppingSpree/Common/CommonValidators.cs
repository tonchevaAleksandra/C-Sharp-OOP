using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree.Common
{
    public static class CommonValidators
    {
        private const decimal MoneyMinValue = 0; 
        public static void ValidateName(string value)
        {
            if(String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
        }
        public static void ValidateSum(decimal value)
        {
            if(value<MoneyMinValue)
            {
                throw new ArgumentException("Money cannot be negative");
            }
        }
    }
}
