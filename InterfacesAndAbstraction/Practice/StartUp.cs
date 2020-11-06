using System;
using System.Collections.Generic;

namespace Practice
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat();
            cat.Draw();
            Draw(new Cat());
            var animal = new Cat();
            var animals = new List<Animal>();
        }

        private static void Draw(IDrawable drawable)
        {
           
        }
    }
}
