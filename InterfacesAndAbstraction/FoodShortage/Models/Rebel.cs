using FoodShortage.Contracts;

namespace FoodShortage.Models
{
    public class Rebel : IHuman, IBuyer
    {
        private const int FOOD_INCREASER = 5;
        private int food;
        public Rebel()
        {
            this.food = 0;
        }
        public Rebel(string name, int age, string group)
            :this()
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }
        public string Name { get; private set; }

        public int Age { get; private set; }
        public string Group { get; }
        public int Food { get;  set; }

        public void BuyFood() =>
            this.Food += FOOD_INCREASER;
    }
}
