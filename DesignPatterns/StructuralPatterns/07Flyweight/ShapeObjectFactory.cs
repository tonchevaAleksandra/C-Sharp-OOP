using System;
using System.Collections.Generic;

namespace Flyweight
{
    public class ShapeObjectFactory
    {
        private Dictionary<string, IShape> shapes;

        public ShapeObjectFactory()
        {
            this.shapes = new Dictionary<string, IShape>();
        }

        public int TotalObjectsCreated => shapes.Count;

        public IShape GetShape(string shapeName)
        {
            IShape shape = null;

            if (shapes.ContainsKey(shapeName))
            {
                shape = shapes[shapeName];
            }
            else
            {
                switch (shapeName)
                {
                    case "Triangle":
                        shape = new Triangle();
                        shapes.Add("Triangle", shape);
                        break;
                    case "Square":
                        shape = new Square();
                        shapes.Add("Square", shape);
                        break;
                    default:
                        throw new Exception("The factory cannot " +
                                            "create the object specified");
                }
            }

            return shape;
        }
    }
}