using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShoppingSpree.Models;

namespace ShoppingSpree.Core
{
    public class Engine
    {
        private List<Product> products;
        private readonly List<Person> people;
        public Engine()
        {
            this.products = new List<Product>();
            this.people = new List<Person>();
        }
        public void Run()
        {
            AddPeople();
            AddPrduct();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string personName = commandArgs[0];
                string productName = commandArgs[1];
                try
                {
                    Person person = this.people
                        .First(p => p.Name == personName);
                    Product product = this.products
                        .First(p => p.Name == productName);

                    person.BuyProduct(product);

                    Console.WriteLine($"{person.Name} bought {product.Name}");

                }
                catch (InvalidOperationException msg)
                {
                    Console.WriteLine(msg.Message);
                }

            }

            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (Person person in this.people)
            {
                Console.WriteLine(person.ToString());
            }
        }

        private void AddPrduct()
        {
            string[] productArgs = Console.ReadLine()
           .Split(";", StringSplitOptions.RemoveEmptyEntries)
           .ToArray();

            for (int i = 0; i < productArgs.Length; i++)
            {
                string[] producttokens = productArgs[i]
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = producttokens[0];
                decimal cost = decimal.Parse(producttokens[1]);

                Product product = new Product(name, cost);
                this.products.Add(product);

            }
        }

        private void AddPeople()
        {
            string[] peopleArgs = Console.ReadLine()
           .Split(";", StringSplitOptions.RemoveEmptyEntries)
           .ToArray();
            for (int i = 0; i < peopleArgs.Length; i++)
            {
                string[] currTokens = peopleArgs[i]
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = currTokens[0];
                decimal money = decimal.Parse(currTokens[1]);

                Person person = new Person(name, money);

                this.people.Add(person);
            }
        }
    }
}
