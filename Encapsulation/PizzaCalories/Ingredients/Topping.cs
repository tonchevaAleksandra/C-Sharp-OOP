using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories.Ingredients
{
    public class Topping
    {
        private const double BaseCaloriesPerGram = 2;
        private const double MinWieght = 1;
        private const double MaxWeight = 50;
        private readonly Dictionary<string, double> DefaultToppingTypes = new Dictionary<string, double>
        {
            {"meat",1.2 },
            {"veggies",0.8 },
            {"cheese",1.1 },
            {"sauce",0.9 }
        };

        private double weight;
        private string type;
        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }
        public string Type
        {
            get { return this.type; }
            private set
            {
                if (!this.DefaultToppingTypes.ContainsKey(value.ToLower()))
                {
                    string valueString = value.First().ToString().ToUpper() + value.Substring(1);
                    throw new ArgumentException($"Cannot place {valueString} on top of your pizza.");
                }

                this.type = value.ToLower();
            }
        }

        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < MinWieght || value > MaxWeight)
                {
                    string typeString = this.Type.First().ToString().ToUpper() + this.Type.Substring(1);
                    throw new ArgumentException($"{typeString} weight should be in the range [{MinWieght}..{MaxWeight}].");
                }

                this.weight = value;
            }
        }

        public double Calories => (BaseCaloriesPerGram * this.Weight)
                * this.DefaultToppingTypes[this.Type];

    }
}
