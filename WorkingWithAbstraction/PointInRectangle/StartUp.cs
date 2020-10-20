using System;
using System.Linq;

namespace PointInRectangle
{
  public  class StartUp
    {
        static void Main(string[] args)
        {

            int[] targets = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
            Point topleft = new Point(targets[0], targets[1]);
            Point bottomRight = new Point(targets[2], targets[3]);
            Rectangle rectangle = new Rectangle(topleft, bottomRight);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int[] coordinates = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
                int x = coordinates[0];
                int y = coordinates[1];
                Point current = new Point(x, y);
                Console.WriteLine(rectangle.Contains(current));
            }
        }
    }
}