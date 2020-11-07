
namespace FoodShortage.Contracts
{
    public interface IBuyer
    {
        string Name { get; }
        int Food { get; set; }
        void BuyFood();
    }
}
