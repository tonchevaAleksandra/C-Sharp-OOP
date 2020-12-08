using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double CubicCnts = 5000;
        private const int MinHP = 400;
        private const int MaxHP = 600;
        public MuscleCar(string model, int horsePower) : base(model, horsePower, CubicCnts, MinHP, MaxHP)
        {
        }

      
    }
}
