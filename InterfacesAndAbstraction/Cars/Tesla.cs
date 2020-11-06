using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : Car,IElectricCar
    {
        public int Battery { get; }

      
        public Tesla(string model, string color, int battery)
            :base(model, color)
        {
            this.Battery = battery;
        }
        public override string ToString()
        {   
            return $"{this.Color} {this} {this.Model} with {this.Battery} Batteries\n{this.Start()}\n{this.Stop()}";
        }
    }
}
