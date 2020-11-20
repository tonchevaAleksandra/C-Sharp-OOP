namespace State
{
    public class PremiumState : State
    {
        public PremiumState(State state)
            : this(state.Balance, state.Account)
        { }

        public PremiumState(double balance, Account account)
        {
            this.Balance = balance;
            this.Account = account;

            Initialize();
        }

        private void Initialize()
        {
            this.interest = 0.05;
            this.lowerLimit = 1000.0;
            this.upperLimit = 10000000.0;
        }

        public override void Deposit(double amount)
        {
            this.Balance += amount;

            this.StateChangeCheck();
        }

        public override void Withdraw(double amount)
        {
            this.Balance -= amount;
            this.StateChangeCheck();
        }

        public override void PayInterest()
        {
            this.Balance += interest * Balance;

            this.StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if (this.Balance < 0.0)
            {
                this.Account.State = new OverdrawnState(this);
            }
            else if (this.Balance < this.lowerLimit)
            {
                this.Account.State = new StandardState(this);
            }
        }
    }
}