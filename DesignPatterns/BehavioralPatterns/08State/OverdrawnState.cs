using System;

namespace State
{
    public class OverdrawnState : State
    {
        private double serviceFee;

        public OverdrawnState(State state)
        {
            this.Balance = state.Balance;
            this.Account = state.Account;

            Initialize();
        }

        private void Initialize()
        {
            this.interest = 0.0;
            this.lowerLimit = -100.0;
            this.upperLimit = 0.0;
            this.serviceFee = 15.00;
        }

        public override void Deposit(double amount)
        {
            this.Balance += amount;

            this.StateChangeCheck();
        }

        public override void Withdraw(double amount)
        {
            amount = amount - serviceFee;
            
            Console.WriteLine("No funds available for withdrawal!");
        }

        public override void PayInterest()
        {
            // No interest is paid
        }

        private void StateChangeCheck()
        {
            if (Balance > upperLimit)
            {
                this.Account.State = new StandardState(this);
            }
        }
    }
}