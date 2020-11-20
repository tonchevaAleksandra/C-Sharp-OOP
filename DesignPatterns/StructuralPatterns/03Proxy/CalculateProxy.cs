namespace Proxy
{
    public class CalculateProxy : IMath
    {
        private Math math;

        public CalculateProxy()
        {
            this.math = new Math();
        }

        public double Add(double x, double y)
        {
            return math.Add(x, y);
        }

        public double Subtract(double x, double y)
        {
            return math.Subtract(x, y);
        }
        
        public double Multiply(double x, double y)
        {
            return math.Multiply(x, y);
        }
        
        public double Divide(double x, double y)
        {
            return math.Divide(x, y);
        }
    }
}