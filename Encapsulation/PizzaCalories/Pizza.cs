using System;
using System.Collections.Generic;
using PizzaCalories.Ingredients;

namespace PizzaCalories
{
   public class Pizza
    {
        private const int MinNameLength = 1;
        private const int MaxNameLength = 15;
        private const int MaxToppingsCount = 10;
        private string name;
        private readonly List<Topping> toppings;
        private Dough dough;
        
        public Pizza()
        {
            this.toppings = new List<Topping>();
        }
        public Pizza(string name)
            :this()
        {
            this.Name = name;
        }
        public string Name
        {
            get { return this.name; }
            set 
            { 
                if(String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value) || value.Length>MaxNameLength || value.Length < MinNameLength)
                {
                    throw new ArgumentException($"Pizza name should be between {MinNameLength} and {MaxNameLength} symbols.");
                }

                this.name = value; 
            }
        }
        
        public Dough Dough
        {
            get { return this.dough; }
            set { this.dough = value; }
        }
        public int CountToppings => this.toppings.Count;
        public void AddTopping(Topping topping)
        {
            if(this.CountToppings==MaxToppingsCount)
            {
                throw new ArgumentException($"Number of toppings should be in range [0..{MaxToppingsCount}].");
            }

            this.toppings.Add(topping);
        }

        public double TotalCalories => CalculateTotalCalories();

        private double CalculateTotalCalories()
        {
            double result = this.Dough.Calories;

            foreach (Topping topping in this.toppings)
            {
                result += topping.Calories;
            }

            return result;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:F2} Calories.";
        }
    }
}
