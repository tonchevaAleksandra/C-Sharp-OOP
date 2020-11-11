using System;

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

        public static void SomeStaticMethod()
        {
            Console.WriteLine("From static");
        }
        public void Move()
        {
           Console.WriteLine($"{this.Name} is moving.");
        }

        public void Move(int x, int y)
        {
            Console.WriteLine($"{this.Name} moved to {x},{y}");
        }
    }
}
