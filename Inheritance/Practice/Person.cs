
namespace Practice
{
   public class Person
    {
        private int age;
        public string Name { get; set; }
        public string Adress { get; set; }
        public int Age 
        {
            get => this.age;
            set => this.age = value;
        }
    }
}
