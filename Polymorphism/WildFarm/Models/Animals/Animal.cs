using System;
using System.Collections.Generic;

using WildFarm.Exceptions;
using WildFarm.Models.Foods.Contracts;
using WildFarm.Models.Animals.Contracts;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private const string UneatableFoodMsg = "{0} does not eat {1}!";
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract double WeightMultiplier { get; }

        public abstract ICollection<Type> PreferedFoods { get; }

        public abstract string ProduceSound();
        public void Feed(IFood food)
        {
            if(!this.PreferedFoods.Contains(food.GetType()))
            {
                throw new InvalidPreferedFoodException(string.Format(UneatableFoodMsg, this.GetType().Name, food.GetType().Name));
            }

            this.Weight += this.WeightMultiplier * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }

    }
}
