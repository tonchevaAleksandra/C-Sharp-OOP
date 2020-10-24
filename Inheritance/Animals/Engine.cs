using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class Engine
    {
        private const string END_OF_INPUT_COMMAND = "Beast!";

        private readonly List<Animal> animals;
        public Engine()
        {
            this.animals = new List<Animal>();
        }
        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != END_OF_INPUT_COMMAND)
            {
                string type = input;
                string[] animalArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Animal animal;
                try
                {
                    animal = GetAnimal(type, animalArgs);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                

                this.animals.Add(animal);
            }

            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (Animal animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Animal GetAnimal(string type, string[] animalArgs)
        {
            string name = animalArgs[0];
            int age = int.Parse(animalArgs[1]);
            string gender = null;
            gender = GetGender(animalArgs, gender);

            Animal animal;
            if (type == "Dog")
            {
                animal = new Dog(name, age, gender);
            }
            else if (type == "Frog")
            {
                animal = new Frog(name, age, gender);
            }
            else if (type == "Cat")
            {
                animal = new Cat(name, age, gender);
            }
            else if (type == "Kitten")
            {
                animal = new Kitten(name, age);
            }
            else if (type == "Tomcat")
            {
                animal = new Tomcat(name, age);
            }
            else
            {
                throw new ArgumentException("Invalid input!");
            }

            return animal;
        }

        private static string GetGender(string[] animalArgs, string gender)
        {
            if (animalArgs.Length >= 3)
            {
                gender = animalArgs[2];
            }

            return gender;
        }

      
    }
}
