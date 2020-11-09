using System.Linq;
using System.Collections.Generic;

using WildFarm.Exceptions;
using WildFarm.Factories;
using WildFarm.IO.Contracts;
using WildFarm.Core.Contracts;
using WildFarm.Models.Foods.Contracts;
using WildFarm.Models.Animals.Contracts;


namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private IReadable reader;
        private IWritable writer;
        private ICollection<IAnimal> animals;
        private AnimalFactory animalFactory;
        private FoodFactory foodFactory;
        public Engine(IReadable reader, IWritable writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.animals = new List<IAnimal>();
            this.animalFactory = new AnimalFactory();
            this.foodFactory = new FoodFactory();
        }
        public void Run()
        {
            string input;
            while ((input = this.reader.ReadLine()) != "End")
            {
                string[] animalArgs = input
                    .Split()
                    .ToArray();
                string[] foodArgs = this.reader.ReadLine()
                    .Split()
                    .ToArray();

                IAnimal animal = animalFactory.CreateAnimal(animalArgs);
                this.animals.Add(animal);
                IFood food = foodFactory.ProduceFood(foodArgs);

                this.writer.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Feed(food);
                }
                catch (InvalidPreferedFoodException msg)
                {
                    this.writer.WriteLine(msg.Message);
                    continue;
                }
            }
            
            PrintAnimalsInfo();

        }

        private void PrintAnimalsInfo()
        {
            foreach (var animal in this.animals)
            {
                this.writer.WriteLine(animal.ToString());
            }
        }
    }
}
