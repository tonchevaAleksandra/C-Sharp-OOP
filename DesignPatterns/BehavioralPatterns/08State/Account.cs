using System;

namespace State
{
    public class Account
    {
        private string owner;

        public Account(string owner)
        {
            this.owner = owner;
            this.State = new StandardState(0.0, this);
        }

        public double Balance => State.Balance;

        public State State { get; set; }

        public void Deposit(double amount)
        {
            this.State.Deposit(amount);

            Console.WriteLine("Deposited {0:C} --- ", amount);
            Console.WriteLine(" Balance = {0:C}", this.Balance);
            Console.WriteLine(" Status = {0}",
                this.State.GetType().Name);
            Console.WriteLine("");
        }

        public void Withdraw(double amount)
        {
            this.State.Withdraw(amount);
            Console.WriteLine("Withdrew {0:C} --- ", amount);
            Console.WriteLine(" Balance = {0:C}", this.Balance);
            Console.WriteLine(" Status = {0}\n",
                this.State.GetType().Name);
        }

        public void PayInterest()
        {
            State.PayInterest();
            Console.WriteLine("Interest Paid --- ");
            Console.WriteLine(" Balance = {0:C}", this.Balance);
            Console.WriteLine(" Status = {0}\n",
                this.State.GetType().Name);
        }
    }
}