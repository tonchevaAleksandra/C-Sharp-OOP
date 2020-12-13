namespace Bakery.Models.Tables
{
    public class OutsideTable : Table
    {
        private const decimal PricePerson = 3.50m;

        public OutsideTable(int tableNumber, int capacity)
            : base(tableNumber, capacity, PricePerson)
        {
        }
    }
}