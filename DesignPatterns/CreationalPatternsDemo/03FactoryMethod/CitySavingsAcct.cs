namespace FactoryMethod
{
    public class CitySavingsAcct : ISavingsAccount
    {
        public CitySavingsAcct()
        {
           this.Balance = 5000;
        }
    }
}