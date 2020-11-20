namespace FactoryMethod
{
    public class NationalSavingsAcct : ISavingsAccount
    {
        public NationalSavingsAcct()
        {
            this.Balance = 2000;
        }
    }
}