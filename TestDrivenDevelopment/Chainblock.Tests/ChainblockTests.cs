using System;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

using Chainblock.Common;
using Chainblock.Contracts;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private IChainblock chainblock;
        private ITransaction transaction;

        [SetUp]
        public void SetUpChainblock()
        {
            this.chainblock = new Core.Chainblock();
            this.transaction = new Transaction(1, TransactionStatus.Successfull, "Sender", "Receiver", 50.00);
        }
        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            int expectedInitialCount = 0;

            IChainblock chainblock = new Core.Chainblock();


            Assert.That(chainblock.Count, Is.EqualTo(expectedInitialCount));
        }

        [Test]
        public void AddShouldIncreaseCountWhenSuccessfull()
        {
            int expectedCount = 1;

            this.chainblock.Add(transaction);

            Transaction transactionInChainblock = (Transaction)this.chainblock.GetById(this.transaction.Id);
            Assert.That(this.chainblock.Count, Is.EqualTo(expectedCount));
            Assert.That(transactionInChainblock.Id, Is.EqualTo(this.transaction.Id));
            Assert.That(transactionInChainblock.Status, Is.EqualTo(this.transaction.Status));
            Assert.That(transactionInChainblock.From, Is.EqualTo(this.transaction.From));
            Assert.That(transactionInChainblock.To, Is.EqualTo(this.transaction.To));
            Assert.That(transactionInChainblock.Amount, Is.EqualTo(this.transaction.Amount));
        }

        [Test]
        public void AddingExistingTransactionIDShouldThrowException()
        {
            this.chainblock.Add(this.transaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.Add(this.transaction);
            }, ExceptionMessages.AddingExistingIdTransactionMessage);
        }

        [Test]
        public void AddingTheSameTransactionWithDifferentIDShouldPass()
        {
            int expectedCount = 2;

            this.chainblock.Add(this.transaction);
            this.chainblock.Add(new Transaction(2, TransactionStatus.Successfull, "Sender", "Receiver", 50.00));

            Assert.That(this.chainblock.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void ContainsShouldReturnTrueWithExistingTransaction()
        {
            this.chainblock.Add(this.transaction);
            bool result = this.chainblock.Contains(this.transaction);

            Assert.That(result, Is.True);
        }

        [Test]
        public void ContainsShouldReturnFalseWitnNoхExistingTransaction()
        {
            bool result = this.chainblock.Contains(this.transaction);

            Assert.That(result, Is.False);
        }

        [Test]
        public void ContainsShouldThrowExceptionWithTransactionEqualsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                bool result = this.chainblock.Contains(null);
            }, ExceptionMessages.ContainsNullExceptionMessage);
        }

        [Test]
        public void ContainsIDShouldReturnTrueWhenExistingID()
        {
            this.chainblock.Add(this.transaction);

            bool result = this.chainblock.Contains(this.transaction.Id);

            Assert.That(result, Is.True);
        }

        [Test]
        public void ContainsIDShouldReturnFalseWhenNonExistingID()
        {
            bool result = this.chainblock.Contains(this.transaction.Id);

            Assert.That(result, Is.False);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-2)]
        public void ContainsIDShouldThrowExceptionWhenInvalidId(int id)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                bool result = this.chainblock.Contains(id);
            }, ExceptionMessages.InvalidIdMessage);
        }

        [Test]
        [TestCase(new Object[] { 1, TransactionStatus.Aborted })]
        [TestCase(new Object[] { 1, TransactionStatus.Failed })]
        public void ChangeTransactionStatusShouldWorkCorrectly(int id, TransactionStatus ts)
        {
            this.chainblock.Add(this.transaction);

            this.chainblock.ChangeTransactionStatus(id, ts);
            Transaction transactionSetStatus = (Transaction)this.chainblock.GetById(id);

            Assert.That(transactionSetStatus.Status, Is.EqualTo(ts));
        }

        [Test]
        [TestCase(new Object[] { 1, TransactionStatus.Aborted })]
        [TestCase(new Object[] { 2, TransactionStatus.Failed })]
        public void ChangeTransactionStatusShouldThrowExceptionWithNonExistingID(int id, TransactionStatus ts)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.chainblock.ChangeTransactionStatus(id, ts);
            }, ExceptionMessages.ChangeStatusToNotExistingIDMessage);
        }

        [Test]
        public void RemoveTransactionByIdShouldWorkCorrectlyWhenExistingID()
        {
            int expectedCount = 0;
            this.chainblock.Add(this.transaction);

            this.chainblock.RemoveTransactionById(1);

            Assert.That(this.chainblock.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void RemoveTransactionByIdShouldThrowExceptionWhenNonExistingId(int id)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.RemoveTransactionById(id);
            }, ExceptionMessages.RemoveByIdNotExistingIdMessage);
        }

        [Test]
        public void GetByIdShouldWorkCorrectlyWhenExistingId()
        {
            this.chainblock.Add(this.transaction);
            Transaction tr = (Transaction)this.chainblock.GetById(this.transaction.Id);

            Assert.That(tr.Status, Is.EqualTo(this.transaction.Status));
            Assert.That(tr.From, Is.EqualTo(this.transaction.From));
            Assert.That(tr.To, Is.EqualTo(this.transaction.To));
            Assert.That(tr.Amount, Is.EqualTo(this.transaction.Amount));
        }

        [Test]
        public void GetByIdShouldThrowExceptionWhenNonExistingId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                ITransaction tr = this.chainblock.GetById(this.transaction.Id);
            }, ExceptionMessages.GetByIDNonExistingIDMessage);
        }

        [Test]
        public void GetByTransactionStatusShouldWorkCorrectly()
        {
            this.AddMultipleTransactionToChainblock();

            //this.chainblock.Add(new Transaction(6, TransactionStatus.Successfull, "Pesho", "Ivan", 70.00));
            //  this.chainblock.Add(new Transaction(1, TransactionStatus.Successfull, "Sender", "Receiver", 20.00));

            List<ITransaction> result = this.chainblock.GetByTransactionStatus(TransactionStatus.Successfull).ToList();
            Assert.That(result[0].Id, Is.EqualTo(6));
            Assert.That(result[0].Amount, Is.EqualTo(70.00));
            Assert.That(result[1].Id, Is.EqualTo(1));
            Assert.That(result[1].Amount, Is.EqualTo(20.00));

        }

        [Test]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Aborted)]
        public void GetByTransactionStatusShouldThrowExceptionWhenNonExistingstatus(TransactionStatus tr)
        {
            this.chainblock.Add(this.transaction);
            Assert.Throws<InvalidOperationException>(() =>
            {
                IEnumerable<ITransaction> trs = this.chainblock.GetByTransactionStatus(tr);
            }, ExceptionMessages.GetByTransactionStatusNonExistingStatusMessage);
        }

        [Test]
        public void GetSendersWithTransactionStatusShouldWorkCorrectly()
        {
            this.AddMultipleTransactionToChainblock();

            List<string> result = this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull).ToList();
            //this.chainblock.Add(new Transaction(6, TransactionStatus.Successfull, "Pesho", "Ivan", 70.00));
            //  this.chainblock.Add(new Transaction(1, TransactionStatus.Successfull, "Sender", "Receiver", 20.00));

            Assert.That(result[0], Is.EqualTo("Pesho"));
            Assert.That(result[1], Is.EqualTo("Sender"));

        }

        [Test]
        public void GetSendersWithTransactionStatusShouldThrowExceptionWhenNonExistingStatus()
        {
            this.chainblock.Add(this.transaction);
            Assert.Throws<InvalidOperationException>(() =>
            {
                IEnumerable<String> result = this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Aborted);
            }, ExceptionMessages.GetAllSendersWithNonExistingTransactionStatusMessage);

        }

        [Test]
        public void GetReceiversWithTransactionStatusShouldWorkCorrectly()
        {
            this.AddMultipleTransactionToChainblock();

            List<string> result = this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull).ToList();
            //this.chainblock.Add(new Transaction(6, TransactionStatus.Successfull, "Pesho", "Ivan", 70.00));
            //  this.chainblock.Add(new Transaction(1, TransactionStatus.Successfull, "Sender", "Receiver", 20.00));

            Assert.That(result[0], Is.EqualTo("Ivan"));
            Assert.That(result[1], Is.EqualTo("Receiver"));

        }
        [Test]
        public void GetReceiversWithTransactionStatusShouldThrowExceptionWhenNonExistingStatus()
        {
            this.chainblock.Add(this.transaction);
            Assert.Throws<InvalidOperationException>(() =>
            {
                IEnumerable<String> result = this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Aborted);
            }, ExceptionMessages.GetAllReceiversWithNonExistingTransactionStatusMessage);

        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldWorkCorrectly()
        {
            this.chainblock.Add(new Transaction(6, TransactionStatus.Successfull, "Pesho", "Ivan", 70.00));
            this.chainblock.Add(new Transaction(7, TransactionStatus.Failed, "Sender", "Receiver", 80.00));
            this.chainblock.Add(new Transaction(8, TransactionStatus.Unauthorized, "Pesho", "Ivan", 90.00));
            this.chainblock.Add(new Transaction(9, TransactionStatus.Unauthorized, "Pesho", "Ivan", 90.00));

            List<ITransaction> result = this.chainblock.GetAllOrderedByAmountDescendingThenById().ToList();

            Assert.That(result[0].Id, Is.EqualTo(8));
            Assert.That(result[1].Id, Is.EqualTo(9));
            Assert.That(result[2].Id, Is.EqualTo(7));
            Assert.That(result[3].Id, Is.EqualTo(6));

        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldThrowExceptionIfNoTransactions()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                List<ITransaction> result = this.chainblock.GetAllOrderedByAmountDescendingThenById().ToList();
            }, ExceptionMessages.EmptyChainblockMessage);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldWorkCorrectly()
        {
            string sender = "Sender";
            this.AddMultipleTransactionToChainblock();

            List<ITransaction> result = this.chainblock.GetBySenderOrderedByAmountDescending(sender).ToList();

            // this.chainblock.Add(new Transaction(7, TransactionStatus.Failed, "Sender", "Receiver", 80.00));
            // this.chainblock.Add(new Transaction(5, TransactionStatus.Aborted, "Sender", "Receiver", 60.00));
            //this.chainblock.Add(new Transaction(3, TransactionStatus.Failed, "Sender", "Receiver", 40.00));
            //this.chainblock.Add(new Transaction(1, TransactionStatus.Successfull, "Sender", "Receiver", 20.00));
            Assert.That(result[0].Amount, Is.EqualTo(80.00));
            Assert.That(result[1].Amount, Is.EqualTo(60.00));
            Assert.That(result[2].Amount, Is.EqualTo(40.00));
            Assert.That(result[3].Amount, Is.EqualTo(20.00));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldThrowExceptionIfNoSuchTransactions()
        {
            this.AddMultipleTransactionToChainblock();
            string sender = "Aleksandra";

            Assert.Throws<InvalidOperationException>(() =>
            {
                List<ITransaction> result = this.chainblock.GetBySenderOrderedByAmountDescending(sender).ToList();
            }, ExceptionMessages.GetBySenderOrderedByAmountDescendingExceptionMessage);
        }
        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldThrowExceptionIfNoTransactions()
        {
            string sender = "Aleksandra";

            Assert.Throws<InvalidOperationException>(() =>
            {
                List<ITransaction> result = this.chainblock.GetBySenderOrderedByAmountDescending(sender).ToList();
            }, ExceptionMessages.EmptyChainblockMessage);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldWorkCorrectly()
        {
            string receiver = "Ivan";
            this.AddMultipleTransactionToChainblock();
            List<ITransaction> result = this.chainblock.GetByReceiverOrderedByAmountThenById(receiver).ToList();
            //this.chainblock.Add(new Transaction(8, TransactionStatus.Unauthorized, "Pesho", "Ivan", 90.00));
            //this.chainblock.Add(new Transaction(9, TransactionStatus.Unauthorized, "Pesho", "Ivan", 90.00));
            //this.chainblock.Add(new Transaction(6, TransactionStatus.Successfull, "Pesho", "Ivan", 70.00));
            //this.chainblock.Add(new Transaction(4, TransactionStatus.Unauthorized, "Pesho", "Ivan", 50.00));
            //this.chainblock.Add(new Transaction(2, TransactionStatus.Aborted, "Pesho", "Ivan", 30.00));
            Assert.That(result[0].Amount, Is.EqualTo(90.00));
            Assert.That(result[0].Id, Is.EqualTo(8));
            Assert.That(result[1].Amount, Is.EqualTo(90.00));
            Assert.That(result[1].Id, Is.EqualTo(9));
            Assert.That(result[2].Amount, Is.EqualTo(70.00));
            Assert.That(result[3].Amount, Is.EqualTo(50.00));
            Assert.That(result[4].Amount, Is.EqualTo(30.00));

        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldThrowExceptionIfNoSuchTransactions()
        {
            string receiver = "Aleksandra";
            this.AddMultipleTransactionToChainblock();

            Assert.Throws<InvalidOperationException>(() =>
            {
                List<ITransaction> result = this.chainblock.GetByReceiverOrderedByAmountThenById(receiver).ToList();
            }, ExceptionMessages
            .GetByReceiverOrderedByAmountThenByIdExceptionMessage);

        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldThrowExceptionIfNoTransactions()
        {
            string receiver = "Aleksandra";


            Assert.Throws<InvalidOperationException>(() =>
            {
                List<ITransaction> result = this.chainblock.GetByReceiverOrderedByAmountThenById(receiver).ToList();
            }, ExceptionMessages
            .EmptyChainblockMessage);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldWorkCorrectly()
        {
            this.AddMultipleTransactionToChainblock();
            int expectedCount = 2;
            TransactionStatus ts = TransactionStatus.Failed;
            double amount = 80.00;
            List<ITransaction> result = this.chainblock.GetByTransactionStatusAndMaximumAmount(ts, amount).ToList();
            // this.chainblock.Add(new Transaction(7, TransactionStatus.Failed, "Sender", "Receiver", 80.00));
            //  this.chainblock.Add(new Transaction(3, TransactionStatus.Failed, "Sender", "Receiver", 40.00));
            Assert.That(result[0].Amount, Is.EqualTo(80.00));
            Assert.That(result[0].Status, Is.EqualTo(ts));
            Assert.That(result[1].Amount, Is.EqualTo(40.00));
            Assert.That(result[1].Status, Is.EqualTo(ts));
            Assert.That(result.Count, Is.EqualTo(expectedCount));

        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldReturnEmptyCollectionIfNoSuchTransactions()
        {
            this.AddMultipleTransactionToChainblock();
            TransactionStatus ts = TransactionStatus.Unauthorized;
            double amount = 19.00;
            int expectedCount = 0;

            List<ITransaction> result = this.chainblock.GetByTransactionStatusAndMaximumAmount(ts, amount).ToList();

            CollectionAssert.IsEmpty(result);
            Assert.That(result.Count, Is.EqualTo(expectedCount));

        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldWorkCorrectly()
        {
            int expectedCount = 2;
            string sender = "Sender";
            double minAmount = 55.00;
            this.AddMultipleTransactionToChainblock();
            //this.chainblock.Add(new Transaction(7, TransactionStatus.Failed, "Sender", "Receiver", 80.00));
            // this.chainblock.Add(new Transaction(5, TransactionStatus.Aborted, "Sender", "Receiver", 60.00));

            List<ITransaction> result = this.chainblock.GetBySenderAndMinimumAmountDescending(sender, minAmount).ToList();

            Assert.That(result.Count, Is.EqualTo(expectedCount));
            Assert.That(result[0].From, Is.EqualTo(sender));
            Assert.That(result[0].Amount, Is.EqualTo(80.00));
            Assert.That(result[1].From, Is.EqualTo(sender));
            Assert.That(result[1].Amount, Is.EqualTo(60.00));

        }

        [Test]
        [TestCase(new object[] { "Aleksandra", 50.00 })]
        [TestCase(new object[] { "Pesho", 150.00 })]
        public void GetBySenderAndMinimumAmountDescShouldThrowExceptionWhenNoMatchesFoune(string sender, double minAmount)
        {
            this.AddMultipleTransactionToChainblock();

            Assert.Throws<InvalidOperationException>(() =>
            {
                List<ITransaction> result = this.chainblock.GetBySenderAndMinimumAmountDescending(sender, minAmount).ToList();
            }, ExceptionMessages.GetBySenderAndMinimumAmountDescendingExceptionMessage);
        }

        [Test]
        public void GetByReceiverAndAmountRangeShouldWorkCorrectly()
        {
            //orderByDescendingAmount !!!!
            string receiver = "Receiver";
            double lo = 40.00;
            double hi = 80.00;
            int expectedCount = 2;
            this.AddMultipleTransactionToChainblock();

            List<ITransaction> result = this.chainblock.GetByReceiverAndAmountRange(receiver, lo, hi).ToList();
            //  this.chainblock.Add(new Transaction(5, TransactionStatus.Aborted, "Sender", "Receiver", 60.00));
            //   this.chainblock.Add(new Transaction(3, TransactionStatus.Failed, "Sender", "Receiver", 40.00));

            Assert.That(result.Count, Is.EqualTo(expectedCount));
            Assert.That(result[0].To, Is.EqualTo(receiver));
            Assert.That(result[0].Amount, Is.EqualTo(60.00));
            Assert.That(result[1].To, Is.EqualTo(receiver));
            Assert.That(result[1].Amount, Is.EqualTo(40.00));

        }

        [Test]
        [TestCase(new Object[] { "Aleksandra", 20.00, 300.00 })]
        [TestCase(new Object[] { "Ivan", 1000.00, 3000.00 })]
        public void GetByReceiverAndAmountRangeShouldThrowExceptionWhenNoMatchesFound(string receiver, double lo, double hi)
        {
            this.AddMultipleTransactionToChainblock();

            Assert.Throws<InvalidOperationException>(() =>
            {
                List<ITransaction> result = this.chainblock.GetByReceiverAndAmountRange(receiver, lo, hi).ToList();
            }, ExceptionMessages.GetByReceiverAndAmountRangeExceptionMessage);
        }

        [Test]
        public void GetAllInAmountRangeShouldWorkCorrectly()
        {
            //lo & hi inclusive
            //insertionOrder
            double lo = 80.00;
            double hi = 90.00;
            int expectedCount = 3;
            this.AddMultipleTransactionToChainblock();
            //this.chainblock.Add(new Transaction(7, TransactionStatus.Failed, "Sender", "Receiver", 80.00));
            //this.chainblock.Add(new Transaction(8, TransactionStatus.Unauthorized, "Pesho", "Ivan", 90.00));
            //this.chainblock.Add(new Transaction(9, TransactionStatus.Unauthorized, "Pesho", "Ivan", 90.00));

            List<ITransaction> result = this.chainblock.GetAllInAmountRange(lo, hi).ToList();

            Assert.That(result.Count, Is.EqualTo(expectedCount));
            Assert.That(result[0].Id, Is.EqualTo(7));
            Assert.That(result[1].Id, Is.EqualTo(8));
            Assert.That(result[2].Id, Is.EqualTo(9));

        }

        [Test]
        [TestCase(new object[] { 81.00, 89.00})]
        [TestCase(new object[] { 21.00, 29.00 })]
        public void GetAllInAmountRangeShouldReturnEmptyCollectionWhenNoMatchesFound(double lo, double hi)
        {
            this.AddMultipleTransactionToChainblock();

            List<ITransaction> result = this.chainblock.GetAllInAmountRange(lo, hi).ToList();

            CollectionAssert.IsEmpty(result);

        }



        private void AddMultipleTransactionToChainblock()
        {
            this.chainblock.Add(new Transaction(1, TransactionStatus.Successfull, "Sender", "Receiver", 20.00));
            this.chainblock.Add(new Transaction(2, TransactionStatus.Aborted, "Pesho", "Ivan", 30.00));
            this.chainblock.Add(new Transaction(3, TransactionStatus.Failed, "Sender", "Receiver", 40.00));
            this.chainblock.Add(new Transaction(4, TransactionStatus.Unauthorized, "Pesho", "Ivan", 50.00));
            this.chainblock.Add(new Transaction(5, TransactionStatus.Aborted, "Sender", "Receiver", 60.00));
            this.chainblock.Add(new Transaction(6, TransactionStatus.Successfull, "Pesho", "Ivan", 70.00));
            this.chainblock.Add(new Transaction(7, TransactionStatus.Failed, "Sender", "Receiver", 80.00));
            this.chainblock.Add(new Transaction(8, TransactionStatus.Unauthorized, "Pesho", "Ivan", 90.00));
            this.chainblock.Add(new Transaction(9, TransactionStatus.Unauthorized, "Pesho", "Ivan", 90.00));


        }
    }
}
