using System;
using System.Collections.Generic;

namespace PizzaCalories.Ingredients
{
    public class Dough
    {
        private const double BaseCaloriesPerGram = 2;
        private const double MinWeight = 1;
        private const double MaxWeight = 200;
        private const string MessegeInvalidDough = "Invalid type of dough.";
        private readonly Dictionary<string, double> DefaultFlourTypes = new Dictionary<string, double>
        {
            { "white", 1.5 },
            { "wholegrain", 1.0 }
        };

        private readonly Dictionary<string, double> DefaultBakingTechniques = new Dictionary<string, double>
        {
            {"crispy",0.9 },
            {"chewy",1.1 },
            {"homemade",1.0 }
        };
        private string flourType;

        private string bakingTechnique;
        private double weight;
        public Dough(string flourType, string bakingTachnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTachnique;
            this.Weight = weight;
        }
        public string FlourType
        {
            get { return this.flourType; }
            private set
            {
                if (!this.DefaultFlourTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(MessegeInvalidDough);
                }
                this.flourType = value.ToLower();
            }
        }
        public string BakingTechnique
        {
            get { return this.bakingTechnique; }
            private set
            {
                if (!this.DefaultBakingTechniques.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(MessegeInvalidDough);
                }
                this.bakingTechnique = value.ToLower();
            }
        }
        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"Dough weight should be in the range[{MinWeight}..{MaxWeight}].");
                }
                this.weight = value;
            }
        }

        public double Calories => ((BaseCaloriesPerGram * this.Weight)
                * this.DefaultFlourTypes[this.FlourType]
                * this.DefaultBakingTechniques[this.BakingTechnique]);

    }
}
