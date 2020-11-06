using System;
using System.Collections.Generic;
using System.Text;

namespace Practice
{
    public  abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public int Health { get; private set; }

        public void Eat()
        {
            this.Health += 20;
        }

        public abstract string MakeSound();//instead of virtual
       //this force us to implement the method in child classes
    }
}
