using System;
using System.Collections.Generic;
using System.Text;

namespace Practice
{
    public class Cat :Animal, IDrawable, IMovable
    {
        public Cat()
        {

        }

        public void Draw(IDrawable drawable)
        {
            throw new NotImplementedException();
        }

        public override string MakeSound()
        {
            return "Meow";
        }

        public void Move(int x, int y)
        {
            throw new NotImplementedException();
        }

        internal void Draw()
        {
            throw new NotImplementedException();
        }
       
    }
}
