using System;
using NUnit.Framework;

namespace Bank.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        private decimal amount;
        private string name;
        private BankAccount bankAccount;

        [SetUp]
        public void SetUp()
        {
            this.name = "Pesho";
            this.amount = 5;
            this.bankAccount = new BankAccount(this.name, this.amount);
        }

        [Test]
            public void WhenAccountInitializedWithPositiveValue_AmountIsChanged()
        {
            Assert.That(bankAccount.Amount, Is.EqualTo(this.amount));
        }

        [Test]
        public void WhenAccountInitializedWithNegativeValue_AmountIsChanged()
        {
            amount = -5;
            Assert.Throws<ArgumentException>(() => new BankAccount(name, this.amount));
        }

        [Test]
        public void WhenAccountInitializedWithZeroValue_AmountIsChanged()
        {
            amount = 0;
            bankAccount = new BankAccount(name, amount);
            Assert.That(bankAccount.Amount, Is.EqualTo(this.amount));
            //Assert.Throws<ArgumentException>(() => new BankAccount(name, amount));
        }

    }
}
