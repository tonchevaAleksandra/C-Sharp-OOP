namespace State
{
    public class StandardState : State
    {
        public StandardState(State state)
            : this(state.Balance, state.Account)
        { }

        public StandardState(double balance, Account account)
        {
            this.Balance = balance;
            this.Account = account;

            Initialize();
        }

        private void Initialize()
        {
            this.interest = 0.0;
            this.lowerLimit = 0.0;
            this.upperLimit = 1000.0;
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
            if (Balance < lowerLimit)
            {
                this.Account.State = new OverdrawnState(this);
            }
            else if (Balance > upperLimit)
            {
                this.Account.State = new PremiumState(this);
            }
        }
    }
}