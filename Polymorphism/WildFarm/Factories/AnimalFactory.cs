
using WildFarm.Models.Animals;

namespace WildFarm.Factories
{
    public class AnimalFactory
    {
        public Animal CreateAnimal(string[] parameters)
        {
            string type = parameters[0];
            string name = parameters[1];
            double weight = double.Parse(parameters[2]);
            if (type == "Cat" || type == "Tiger")
            {
                string livingRegion = parameters[3];
                string breed = parameters[4];
                if (type == "Cat")
                    return new Cat(name, weight, livingRegion, breed);
                else
                    return new Tiger(name, weight, livingRegion, breed);
            }
            else if (type == "Owl" || type == "Hen")
            {
                double wingSize = double.Parse(parameters[3]);
                if (type == "Owl")
                    return new Owl(name, weight, wingSize);
                else
                    return new Hen(name, weight, wingSize);
            }
            else if (type == "Mouse" || type == "Dog")
            {
                string livingRegion = parameters[3];
                if (type == "Mouse")
                    return new Mouse(name, weight, livingRegion);
                else
                    return new Dog(name, weight, livingRegion);
            }
            else return null;
        }
    }
}
