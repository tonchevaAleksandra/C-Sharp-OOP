using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
   public class Child:Person
    {
        private const int CHILD_MAX_AGE = 15;
        private int age;
        public Child(string name, int age)
            :base(name, age)
        {
           
        }

        //public override int Age
        //{
        //    get
        //    {
        //        return base.Age;
        //    }
        //    protected set
        //    {
        //        if (value <= CHILD_MAX_AGE)
        //        {
        //            base.Age = value;
        //        }
        //    }
        //}
    }
}
