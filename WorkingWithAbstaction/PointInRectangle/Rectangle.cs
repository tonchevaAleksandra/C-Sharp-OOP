
namespace PointInRectangle
{
  public  class Rectangle
    {
        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

        public Rectangle(Point topleft, Point bottomright)
        {
            this.TopLeft = topleft;
            this.BottomRight = bottomright;
        }
        public bool Contains(Point point)
        {
            var xIsInside = point.X >= this.TopLeft.X && point.X <= this.BottomRight.X;
            var yIsInside = point.Y >= this.TopLeft.Y && point.Y <= this.BottomRight.Y;

            return xIsInside && yIsInside;
        }
    }
}
