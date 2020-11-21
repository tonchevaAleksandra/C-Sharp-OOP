using System;

namespace TemplatePattern
{
    public class SourDough : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for Sourdough Bread!");
        }
        public override void Bake()
        {
            Console.WriteLine("Baking Sourdough Bread. (20 minutes)");
        }

    }
}
