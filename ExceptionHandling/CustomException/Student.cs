using System;
using System.Collections.Generic;
using System.Text;

namespace CustomException
{
    public class Student : Person
    {
        public Student(string firstName, string lastName, int age, string email) 
            : base(firstName, lastName, age)
        {
        }
    }
}
