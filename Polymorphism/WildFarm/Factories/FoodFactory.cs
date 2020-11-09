
using WildFarm.Models.Foods;
using WildFarm.Models.Foods.Contracts;

namespace WildFarm.Factories
{
   public class FoodFactory
    {
        public IFood ProduceFood(string[] foodArgs)
        {
            string type = foodArgs[0];
            int quantity = int.Parse(foodArgs[1]);
            if (type == "Vegetable")
                return new Vegetable(quantity);
            else if (type == "Fruit")
                return new Fruit(quantity);
            else if (type == "Meat")
                return new Meat(quantity);
            else
                return new Seeds(quantity);
         
        }
    }
}
