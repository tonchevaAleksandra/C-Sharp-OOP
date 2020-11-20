using CommandPattern.Contracts;

namespace CommandPattern
{
    public class ProductCommand : ICommand
    {
        private readonly Product _product;
        private readonly PriceAction _priceAction;
        private readonly decimal _amount;

        public ProductCommand(Product product, PriceAction priceAction, decimal amount)
        {
            this._product = product;
            this._priceAction = priceAction;
            this._amount = amount;
        }
        public void ExecuteAction()
        {
            if (this._priceAction == PriceAction.Increase)
                this._product.IncreasePrice(this._amount);

            else
                this._product.DecreasePrice(this._amount);
           
        }
    }
}
