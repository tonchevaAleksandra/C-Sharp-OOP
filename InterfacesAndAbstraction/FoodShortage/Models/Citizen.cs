using FoodShortage.Contracts;

namespace FoodShortage.Models
{
    public class Citizen : IIdentifiable, IHuman, IBirthdatable, IBuyer
    {
        private const int FOOD_INCREASER = 10;
        private int food;

        public Citizen()
        {
            this.food = 0;
        }
        public Citizen(string name, int age, string id, string birthdate)
            :this()
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
            this.Birthdate = birthdate;
        }
        public int Age { get; private set; }
        public string Name { get; private set; }
        public string ID { get; private set; }

        public string Birthdate { get; private set; }

        public int Food { get => food;  set => food = value; }

        public void BuyFood()=>
            this.Food += FOOD_INCREASER;
       
    }
}
