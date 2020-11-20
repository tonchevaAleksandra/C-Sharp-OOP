using System;

namespace Flyweight
{
    public class Startup
    {
        public static void Main()
        {
            ShapeObjectFactory sof = new ShapeObjectFactory();

            IShape shape = sof.GetShape("Triangle");
            shape.Print();
            shape = sof.GetShape("Triangle");
            shape.Print();
            shape = sof.GetShape("Triangle");
            shape.Print();

            shape = sof.GetShape("Square");
            shape.Print();
            shape = sof.GetShape("Square");
            shape.Print();
            shape = sof.GetShape("Square");
            shape.Print();

            int total = sof.TotalObjectsCreated;
            Console.WriteLine($"{Environment.NewLine} Number of objects created = {total}");
        }
    }
}
