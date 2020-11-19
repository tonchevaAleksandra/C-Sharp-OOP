using System;
using NUnit.Framework;

using Chainblock.Common;

namespace Chainblock.Tests
{
    [TestFixture]
   public class TransactionTests
    {
        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            int id = 1;
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Sender";
            string to = "Receiver";
            double amount = 200.00;

            Transaction transaction = new Transaction(id, ts, from, to, amount);

            Assert.That(transaction.Id, Is.EqualTo(id));
            Assert.That(transaction.Status, Is.EqualTo(ts));
            Assert.That(transaction.From, Is.EqualTo(from));
            Assert.That(transaction.To, Is.EqualTo(to));
            Assert.That(transaction.Amount, Is.EqualTo(amount));

        }

     
        [Test]
        [TestCase(0)]
        [TestCase(-2)]
        public void IDShouldThrowExceptionWhenZeroOrNegative(int id)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Transaction transaction = new Transaction(id, TransactionStatus.Successfull, "Sender", "Receiver", 200.00);

            }, ExceptionMessages.InvalidIdMessage);
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void SenderShouldThrowExceptionWhenEmptyNullOrWhiteSpace(string from)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Transaction transaction = new Transaction(1, TransactionStatus.Successfull, from, "Receiver", 200.00);

            }, ExceptionMessages.InvalidSenderUserNameMessage);
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void ReceiverShouldThrowExceptionWhenEmptyNullOrWhiteSpace(string to)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Transaction transaction = new Transaction(1, TransactionStatus.Successfull, "Sender", to, 200.00);

            }, ExceptionMessages.InvalidReceiverUserNameMessage);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-50)]
        public void AmountShouldThrowExceptionWhenZeroOrNegative(double amount)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Transaction transaction = new Transaction(1, TransactionStatus.Successfull, "Sender", "Receiver", amount);
            }, ExceptionMessages.InvalidAmountMessage);
        }
    }
}
