namespace Facade
{
    public class Student
    {
        public Student(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}