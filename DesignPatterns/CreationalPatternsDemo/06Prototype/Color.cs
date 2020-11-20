using System;

namespace Prototype
{
    public class Color : ColorPrototype
    {
        private int yellow;
        private int orange;
        private int purple;

        public Color(int yellow, int orange, int purple)
        {
            this.yellow = yellow;
            this.orange = orange;
            this.purple = purple;
        }

        public override ColorPrototype Clone()
        {
            Console.WriteLine(
                "RGB color is cloned to: {0,3},{1,3},{2,3}",
                yellow, orange, purple);

            return this.MemberwiseClone() as ColorPrototype;
        }
    }
}