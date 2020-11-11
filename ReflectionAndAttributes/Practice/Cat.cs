namespace Practice
{
   public class Cat:Animal
    {
        private string somehiddenField = "Vankata";

        public Cat(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public bool IsSleeping { get; set; }
    }
}
