
namespace Shapes.Models
{
    public class Rectangle : Shape
    {
        private double sideA;
        private double sideB;
        public Rectangle(double height, double width)
        {
            this.sideA = height;
            this.sideB = width;
        }
        public override double CalculateArea()
        {
            return this.sideA * this.sideB;
        }

        public override double CalculatePerimeter()
        {
            return this.sideA * 2 + this.sideB * 2;
        }

        public sealed override string Draw()
        {
            return base.Draw() +"Rectangle";
        }
    }
}
