using NUnit.Framework;
//using Shouldly;
using TestDemos;
//using FluentAssertions;


namespace TestNUnit.Tests
{
    [TestFixture]
   public class BankAccountTests
    {
        [Test]
        public void CreatingBankAccountShouldSetInitialAmount()
        {
            const int amount = 2000;
            var bankAccount = new BankAccount(2000);
            //bankAccount.Amount.ShouldBe(amount);//- this is using SHOULDLY

            /* bankAccount.Amount.Should().Be(amount);*/// using FluentAssertions

            //Assert.AreEqual(2000, bankAccount.Amount); - this is defaulf from NUnit

            Assert.That(bankAccount.Amount, Is.EqualTo(amount));
        }
    }
}
