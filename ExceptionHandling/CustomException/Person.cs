using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomException.Exceptions;

namespace CustomException
{
    public class Person
    {
        private const string INVALID_NAME_MSG = "The {0} name should contains only letters!";
        private const int MIN_AGE = 0;
        private const int MAX_AGE = 120;

        private string firstName;
        private string lastName;
        private int age;
        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("first name", "The first name cannot be null or empty!");
                }
                if (!value.All(c => char.IsLetter(c)))
                {
                    throw new InvalidPersonNameException(string.Format(INVALID_NAME_MSG, "first"));
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("last name", "The last name cannot be null or empty!");
                }
                if (!value.All(c => char.IsLetter(c)))
                {
                    throw new InvalidPersonNameException(string.Format(INVALID_NAME_MSG, "last"));
                }
                this.lastName = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < MIN_AGE || value > MAX_AGE)
                {
                    throw new ArgumentOutOfRangeException("age", $"The age should be in range {MIN_AGE}-{MAX_AGE}!");
                }
                this.age = value;
            }
        }


    }
}
