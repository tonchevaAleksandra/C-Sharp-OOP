using System;

using Chainblock.Common;
using Chainblock.Contracts;

namespace Chainblock
{
    public class Transaction : ITransaction
    {
        private const int MIN_ID_VALUE = 0;
        private const double MIN_AMOUNT_VALUE = 0.0;

        private int id;
        private string from;
        private string to;
        private double amount;

        public Transaction(int id, TransactionStatus status, string from, string to, double amount)
        {
            this.Id = id;
            this.Status = status;
            this.From = from;
            this.To = to;
            this.Amount = amount;
        }
        public int Id 
        {
            get => this.id;
            set
            {
                if (value <= MIN_ID_VALUE)
                    throw new ArgumentException(ExceptionMessages.InvalidIdMessage);

                this.id = value;
            }
        }
        public TransactionStatus Status { get; set; }
        public string From 
        {
            get => this.from;
            set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidSenderUserNameMessage);

                this.from = value;
            }
        }
        public string To 
        {
            get => this.to;
            set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidReceiverUserNameMessage);

                this.to = value;
            
            }
        }
        public double Amount 
        {
            get => this.amount;
            set
            {
                if (value <= MIN_AMOUNT_VALUE)
                    throw new ArgumentException(ExceptionMessages.InvalidAmountMessage);

                this.amount = value;
            }
        }
    }
}
