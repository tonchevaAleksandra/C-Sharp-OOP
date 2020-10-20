
using System.Collections.Generic;
using StudentSystem.Entities;

namespace StudentSystem
{
   public class StudentData
    {

        public Dictionary<string, Student> Students { get; } = new Dictionary<string, Student>();
        public void Add(string name, int age, double grade)
        {
            if (!Students.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                this.Students[name] = student;
            }
        }

        public string GetDetails(string name)
        {
            if (!this.Students.ContainsKey(name)) return null;

            var student = this.Students[name];
            return student.ToString();

        }
    }
}
