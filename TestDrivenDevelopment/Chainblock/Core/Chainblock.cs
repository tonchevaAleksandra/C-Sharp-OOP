using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using Chainblock.Common;
using Chainblock.Contracts;

namespace Chainblock.Core
{
    public class Chainblock : IChainblock
    {
        private const int MIN_ID_VALUE = 0;

        private ICollection<ITransaction> transactions;
        public Chainblock()
        {
            this.transactions = new List<ITransaction>();
        }
        public int Count => this.transactions.Count;

        public void Add(ITransaction tx)
        {
            if (this.transactions.Contains(tx))
                throw new InvalidOperationException(ExceptionMessages.AddingExistingIdTransactionMessage);

            this.transactions.Add(tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!this.transactions.Any(tr => tr.Id == id))
                throw new ArgumentException(ExceptionMessages.ChangeStatusToNotExistingIDMessage);

            ITransaction tr = this.transactions.First(tr => tr.Id == id);
            tr.Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            if (tx == null)
                throw new ArgumentNullException(ExceptionMessages.ContainsNullExceptionMessage);

            return this.transactions.Contains(tx);
        }

        public bool Contains(int id)
        {
            if (id <= MIN_ID_VALUE)
                throw new ArgumentException(ExceptionMessages.InvalidIdMessage);

            return this.transactions.Any(tr => tr.Id == id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            if (!this.transactions.Any(tr => tr.Amount >= lo && tr.Amount <= hi))
                return Enumerable.Empty<ITransaction>();

            return this.transactions.Where(tr => tr.Amount >= lo && tr.Amount <= hi);
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            if (!this.transactions.Any())
                throw new InvalidOperationException(ExceptionMessages.EmptyChainblockMessage);

            return this.transactions.OrderByDescending(tr => tr.Amount).ThenBy(tr => tr.Id);
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            if (!this.transactions.Any(tr => tr.Status.Equals(status)))
                throw new InvalidOperationException(ExceptionMessages.GetAllReceiversWithNonExistingTransactionStatusMessage);

            IEnumerable<ITransaction> trs = this.transactions.Where(tr => tr.Status.Equals(status)).OrderByDescending(tr => tr.Amount);
            List<string> result = new List<string>();
            foreach (ITransaction transaction in trs)
            {
                result.Add(transaction.To);
            }

            return result;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            if (!this.transactions.Any(tr => tr.Status.Equals(status)))
                throw new InvalidOperationException(ExceptionMessages.GetAllSendersWithNonExistingTransactionStatusMessage);

            IEnumerable<ITransaction> trs = this.transactions.Where(tr => tr.Status.Equals(status)).OrderByDescending(tr => tr.Amount);
            List<string> result = new List<string>();
            foreach (ITransaction transaction in trs)
            {
                result.Add(transaction.From);
            }

            return result;
        }
        public ITransaction GetById(int id)
        {
            if (!this.transactions.Any(tr => tr.Id == id))
                throw new InvalidOperationException(ExceptionMessages.GetByIDNonExistingIDMessage);

            return this.transactions.First(tr => tr.Id == id);
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            if (!this.transactions.Any(tr => tr.To == receiver && tr.Amount >= lo && tr.Amount < hi))
                throw new InvalidOperationException(ExceptionMessages.GetByReceiverAndAmountRangeExceptionMessage);

            return this.transactions
                .Where
                (tr => tr.To == receiver &&
                tr.Amount >= lo &&
                tr.Amount < hi)
                .OrderByDescending(tr => tr.Amount)
                .ThenBy(tr => tr.Id);
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            if (!this.transactions.Any())
                throw new InvalidOperationException(ExceptionMessages.EmptyChainblockMessage);

            if (!this.transactions.Any(tr => tr.To == receiver))
                throw new InvalidOperationException(ExceptionMessages.GetByReceiverOrderedByAmountThenByIdExceptionMessage);

            return this.transactions.Where(tr => tr.To == receiver).OrderByDescending(tr => tr.Amount).ThenBy(tr => tr.Id);
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            if (!this.transactions.Any(tr => tr.From == sender && tr.Amount > amount))
                throw new InvalidOperationException(ExceptionMessages.GetBySenderAndMinimumAmountDescendingExceptionMessage);

            return this.transactions.Where(tr => tr.From == sender && tr.Amount > amount).OrderByDescending(tr => tr.Amount);
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            if (!this.transactions.Any())
                throw new InvalidOperationException(ExceptionMessages.EmptyChainblockMessage);

            if (!this.transactions.Any(tr => tr.From == sender))
                throw new InvalidOperationException(ExceptionMessages.GetBySenderOrderedByAmountDescendingExceptionMessage);

            return this.transactions.Where(tr => tr.From == sender).OrderByDescending(tr => tr.Amount);
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            if (!this.transactions.Any(tr => tr.Status.Equals(status)))
                throw new InvalidOperationException(ExceptionMessages
                    .GetByTransactionStatusNonExistingStatusMessage);

            IEnumerable<ITransaction> trs = this.transactions.Where(tr => tr.Status.Equals(status)).OrderByDescending(tr => tr.Amount);

            return trs;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            if (!this.transactions.Any(tr => tr.Status == status && tr.Amount <= amount))
                return Enumerable.Empty<ITransaction>();

            return this.transactions.Where(tr => tr.Status == status && tr.Amount <= amount).OrderByDescending(tr => tr.Amount);
        }

        public IEnumerator<ITransaction> GetEnumerator() => this.transactions.GetEnumerator();

        public void RemoveTransactionById(int id)
        {
            if (!this.transactions.Any(tr => tr.Id == id))
                throw new InvalidOperationException(ExceptionMessages.RemoveByIdNotExistingIdMessage);
            Transaction tr = (Transaction)this.transactions.First(tr => tr.Id == id);
            this.transactions.Remove(tr);
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
