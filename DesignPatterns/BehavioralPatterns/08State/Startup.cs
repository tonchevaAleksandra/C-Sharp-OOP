namespace State
{
    public class Startup
    {
        public static void Main()
        {
            Account account = new Account("John Smith");

            account.Deposit(490.0);
            account.Deposit(390.0);
            account.Deposit(540.0);
            account.PayInterest();
            account.Withdraw(2200.0);
            account.Withdraw(1300.0);
        }
    }
}