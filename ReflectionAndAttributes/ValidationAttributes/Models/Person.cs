using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models
{
   public class Person
    {
        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }
        //[Required] - this is the default class of c#q but this will not validate the value, because we have to make a class Validator to improve the data required 
        [MyRequired]
        public string FullName { get; private set; }

        [MyRange(12,90)]
        public int Age { get; private set; }
    }
}
