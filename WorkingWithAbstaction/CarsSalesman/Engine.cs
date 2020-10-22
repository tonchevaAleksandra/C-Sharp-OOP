using System;
using System.Collections.Generic;
using System.Text;

namespace CarsSalesman
{
   public class Engine
    {
       
        public string Model { get; }
        public int Power { get; }
        public int Displacement { get; }
        public string Efficiency { get; }

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = -1;
            this.Efficiency = "n/a";
        }

        public Engine(string model, int power, int displacement)
            :this(model, power)
        {
            this.Displacement = displacement;
          
        }

        public Engine(string model, int power, string efficiency)
            :this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency)
            :this(model, power)
        {
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Model}:");
            sb.AppendLine($"  Power: {this.Power}");
            string displacementStr = this.Displacement == -1 ? "n/a" : this.Displacement.ToString();
            sb.AppendLine($"  Displacement: {displacementStr}");
            sb.AppendLine($"  Efficiency: {this.Efficiency}");

            return sb.ToString().TrimEnd();
        }
    }
}
