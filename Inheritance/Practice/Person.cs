
namespace Practice
{
   public class Person:IMovableObject, IPerson
    {
        private int age;
        public string Name { get; set; }
        public string Adress { get; set; }
        public int Age 
        {
            get => this.age;
            set => this.age = value;
        }
        public void Move()
        {

        }
        public virtual string SayHello()
        {
            return $"Hello from {this.Name}!";
        }
    }
}
