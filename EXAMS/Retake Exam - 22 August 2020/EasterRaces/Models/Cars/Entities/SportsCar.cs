using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double CubicCnts = 3000;
        private const int MinHP = 250;
        private const int MaxHP = 450;
        public SportsCar(string model, int horsePower ) 
            : base(model, horsePower, CubicCnts, MinHP, MaxHP)
        {
        }
    }
}
