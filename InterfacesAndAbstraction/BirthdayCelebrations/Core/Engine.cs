using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BirthdayCelebrations.Contracts;
using BirthdayCelebrations.Models;

namespace BirthdayCelebrations.Core
{
    public class Engine
    {
        private readonly List<IBirthable> birthables;
        public Engine()
        {
            this.birthables = new List<IBirthable>();
        }
        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inhabitantArgs = input
                    .Split()
                    .ToArray();
                string type = inhabitantArgs[0];
                string name;
                string id;
                string birthdate;

                switch (type)
                {
                    case "Citizen":
                        AddCitizen(inhabitantArgs, out name, out id, out birthdate);
                        break;
                    case "Pet":
                        AddPet(inhabitantArgs, out name, out birthdate);
                        break;
                    default:
                        break;
                }
            }

            string birthyear = Console.ReadLine();
            PrintResult(birthyear);
        }

        private void PrintResult(string birthyear)
        {
            foreach (IBirthable birthable in this.birthables)
            {
                if (birthable.Birthdate.EndsWith(birthyear))
                {
                    Console.WriteLine(birthable.Birthdate);
                }
            }
        }

        private void AddPet(string[] inhabitantArgs, out string name, out string birthdate)
        {
            name = inhabitantArgs[1];
            birthdate = inhabitantArgs[2];
            Pet pet = new Pet(name, birthdate);
            this.birthables.Add(pet);
        }

        private void AddCitizen(string[] inhabitantArgs, out string name, out string id, out string birthdate)
        {
            name = inhabitantArgs[1];
            int age = int.Parse(inhabitantArgs[2]);
            id = inhabitantArgs[3];
            birthdate = inhabitantArgs[4];
            Citizen citizen = new Citizen(name, age, id, birthdate);
            this.birthables.Add(citizen);
        }
    }
}
