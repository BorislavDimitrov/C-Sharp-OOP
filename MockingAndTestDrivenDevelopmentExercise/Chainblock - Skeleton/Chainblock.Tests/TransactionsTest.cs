using Chainblock.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chainblock.Tests
{
    [TestFixture]
    class TransactionsTest
    {
        [Test]
        public void ConstrucorShouldMakeTransaction()
        {
            ITransaction transaction = new Transaction(14, TransactionStatus.Successfull, "Dimitar", "Stoqn", 978.24);
            Assert.AreEqual(14, transaction.Id);
            Assert.AreEqual(TransactionStatus.Successfull, transaction.Status);
            Assert.AreEqual("Dimitar", transaction.From);
            Assert.AreEqual("Stoqn", transaction.To);
            Assert.AreEqual(978.24, transaction.Amount);
        }

        [Test]
        [TestCase(-2, TransactionStatus.Successfull, "Dimitar", "Stoqn", 987.26)]
        [TestCase(2, TransactionStatus.Successfull, "Dimitri4ko", "Stoqn", 987.26)]
        [TestCase(4, TransactionStatus.Successfull, "Dimitar", "Stoqn4o", 987.26)]
        [TestCase(56, TransactionStatus.Successfull, "Dimitar", "Stoqn", 0)]

        public void ConstrucorShouldThrowArgumentException
            (int id, TransactionStatus status, string from, string to, double amount)
        {
            Assert.Throws<ArgumentException>(() => new Transaction(id, status, from, to, amount));
        }
    }
}
