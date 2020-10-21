
namespace HotelReservation
{
    public class PriceCalculator
    {
        public decimal Calculate(decimal pricePerDay, int days, Season season,  Discount discount)
        {
            var price = days * pricePerDay * (int)season;
            price -= (int)discount * price/100;

            return price;
        }
    }
}
