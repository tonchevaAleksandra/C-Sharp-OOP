using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaCalories.Ingredients;

namespace PizzaCalories
{
   public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            try
            {
                Pizza pizza = CreatePizza();
                Dough dough = CreateDough();

                pizza.Dough = dough;
                AddToppingsToPizza(pizza);
                Console.WriteLine(pizza.ToString());
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
           
        }

        private static void AddToppingsToPizza(Pizza pizza)
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] toppingArgs = command
                    .Split()
                    .Skip(1)
                    .ToArray();
                string toppingType = toppingArgs[0];
                double toppingWeight = double.Parse(toppingArgs[1]);
                Topping topping = new Topping(toppingType, toppingWeight);
                pizza.AddTopping(topping);
            }
        }

        private static Dough CreateDough()
        {
            string[] doughArgs = Console.ReadLine()
                                         .Split()
                                         .ToArray();
            string flourtype = doughArgs[1];
            string bakingTechnique = doughArgs[2];
            double doughtWeight = double.Parse(doughArgs[3]);
            Dough dough = new Dough(flourtype, bakingTechnique, doughtWeight);
            return dough;
        }

        private static Pizza CreatePizza()
        {
            string[] pizzaArgs = Console.ReadLine()
                            .Split()
                            .ToArray();
            string pizzaName = pizzaArgs[1];
            Pizza pizza = new Pizza(pizzaName);
            return pizza;
        }
    }
}
