using System;
using System.Collections.Generic;

using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double WEIGHT_MULTIPLIER = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplier => WEIGHT_MULTIPLIER;

        public override ICollection<Type> PreferedFoods =>
            new List<Type>() { typeof(Vegetable), typeof(Meat)};

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
