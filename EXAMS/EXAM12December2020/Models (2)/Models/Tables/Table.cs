using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private readonly List<IBakedFood> foodOrders;
        private readonly List<IDrink> drinkOrders;

        private int capacity;
        private int numberOfPeople;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;

            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
        }

        private IReadOnlyCollection<IBakedFood> FoodOrders
            => this.foodOrders.AsReadOnly();

        private IReadOnlyCollection<IDrink> DrinkOrders
            => this.drinkOrders.AsReadOnly();

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price
            => this.NumberOfPeople * this.PricePerPerson;

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            var totalPriceFood = this.FoodOrders
                .Sum(f => f.Price);

            var totalPriceDrinks = this.DrinkOrders
                .Sum(d => d.Price);

            var totalPriceAll = totalPriceFood + totalPriceDrinks + this.Price;

            return totalPriceAll;
        }

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();

            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        public string GetFreeTableInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}")
            .AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Capacity: {this.Capacity}")
            .AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().Trim();
        }
    }
}