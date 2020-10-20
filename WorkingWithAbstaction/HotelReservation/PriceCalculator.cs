
namespace HotelReservation
{
    public class PriceCalculator
    {
        public decimal Calculate(decimal pricePerDay, int days, Season season, Discount discount = Discount.None)
        {
            var price = days * pricePerDay * (int)season;
            price -= (int)discount * price;

            return price;
        }
    }
}
