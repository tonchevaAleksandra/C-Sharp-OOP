using System;
using System.Collections.Generic;
using System.Linq;
using FoodShortage.Contracts;
using FoodShortage.Models;

namespace FoodShortage.Core
{
   public class Engine
    {
        private readonly List<IBuyer> buyers;
        public Engine()
        {
            this.buyers = new List<IBuyer>();
        }
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                AddBuyers();
            }
            BuyFood();

            PrintTotalFood();
        }

        private void PrintTotalFood()
        {
            int totalFood = 0;
            foreach (var customer in this.buyers)
            {
                totalFood += customer.Food;
            }
            Console.WriteLine(totalFood);
        }

        private void BuyFood()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string name = input;
                if (this.buyers.Any(b => b.Name == name))
                {
                    var customer = this.buyers.FirstOrDefault(b => b.Name == name);
                    customer.BuyFood();

                }
            }
        }

        private void AddBuyers()
        {
            string[] inputArgs = Console.ReadLine()
                .Split()
                .ToArray();
            string name = inputArgs[0];
            int age = int.Parse(inputArgs[1]);
            if (inputArgs.Length == 3)
            {
                string group = inputArgs[2];
                Rebel rebel = new Rebel(name, age, group);
                this.buyers.Add(rebel);
            }
            else
            {
                string id = inputArgs[2];
                string birthdate = inputArgs[3];
                Citizen citizen = new Citizen(name, age, id, birthdate);
                this.buyers.Add(citizen);
            }
        }
    }
}
