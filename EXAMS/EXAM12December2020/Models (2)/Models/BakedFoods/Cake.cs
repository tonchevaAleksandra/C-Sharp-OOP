namespace Bakery.Models.BakedFoods
{
    public class Cake : BakedFood
    {
        private const int CakePortion = 245;

        public Cake(string name, decimal price)
            : base(name, CakePortion, price)
        {
        }
    }
}