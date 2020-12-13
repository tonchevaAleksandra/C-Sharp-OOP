namespace Bakery.Models.BakedFoods
{
    public class Bread : BakedFood
    {
        private const int BreadPortion = 200;

        public Bread(string name, decimal price)
            : base(name, BreadPortion, price)
        {
        }
    }
}