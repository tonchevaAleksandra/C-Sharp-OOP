using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : Car
    {    
        public Seat(string model, string color)
            :base(model, color)
        {
           
        }
        public override string ToString()
        {
            return $"{this.Color} {this} {this.Model}\n{this.Start()}\n{this.Stop()}";
        }
    }
}
