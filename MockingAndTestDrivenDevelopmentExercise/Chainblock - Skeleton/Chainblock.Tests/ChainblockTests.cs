using Chainblock.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock.Tests
{
    [TestFixture]
    class ChainblockTests
    {
        [Test]
        public void ConstructorShouldMakeEmptyChainblock()
        {
            Chainblock chainblock = new Chainblock();
            Assert.AreEqual(0, chainblock.Count);
        }

        [Test]
        public void AddShouldAddTransctions()
        {
            Chainblock chainblock = new Chainblock();
            Mock<ITransaction> transaction1 = new Mock<ITransaction>();
            transaction1.Setup(x => x.Id)
                .Returns( 12);
            Mock<ITransaction> transaction2 = new Mock<ITransaction>();
            transaction2.Setup(x => x.Id)
                .Returns(13);
            Mock<ITransaction> transaction3 = new Mock<ITransaction>();
            transaction3.Setup(x => x.Id)
                .Returns(2);
            chainblock.Add(transaction1.Object);
            chainblock.Add(transaction2.Object);
            chainblock.Add(transaction3.Object);
            Assert.AreEqual(3, chainblock.Count);
        }

        [Test]
        public void ChangeTransactionStatusShouldChangeTheStatusByGivenId()
        {
            Chainblock chainblock = new Chainblock();
            Mock<ITransaction> transaction1 = new Mock<ITransaction>();
            ITransaction transaction = new Transaction(12, TransactionStatus.Failed, "as", "as", 12.2);
            chainblock.Add(transaction);
            chainblock.ChangeTransactionStatus(12, TransactionStatus.Successfull);
            ITransaction result = chainblock.GetById(12);
            Assert.AreEqual(12, result.Id);
            Assert.AreEqual(TransactionStatus.Successfull, result.Status);
        }

        [Test]
        public void ChangeTransactionStatusShouldThrowInvalidArgumentException()
        {
            Chainblock chainblock = new Chainblock();
            Assert.Throws<ArgumentException>(() => chainblock.ChangeTransactionStatus(11, TransactionStatus.Failed));
        }

        [Test]
        public void ContainsMustReturnTrueForId()
        {
            Chainblock chainblock = new Chainblock();
            Mock<ITransaction> transaction = new Mock<ITransaction>();
            transaction.Setup(x => x.Id)
                .Returns(3);
            chainblock.Add(transaction.Object);
            Assert.IsTrue(chainblock.Contains(3));
        }

        [Test]
        public void ContainsMustReturnFalseForId()
        {
            Chainblock chainblock = new Chainblock();
            Assert.IsFalse(chainblock.Contains(3));
        }

        [Test]
        public void ContainsMustReturnTrueForTransaction()
        {
            Chainblock chainblock = new Chainblock();
            Mock<ITransaction> transaction = new Mock<ITransaction>();
            transaction.Setup(x => x.Id)
                .Returns(3);
            chainblock.Add(transaction.Object);
            Assert.IsTrue(chainblock.Contains(transaction.Object));
        }
        [Test]
        public void ContainsMustReturnFalseForTransaction()
        {
            Chainblock chainblock = new Chainblock();
            Mock<ITransaction> transaction = new Mock<ITransaction>();
            transaction.Setup(x => x.Id)
                .Returns(3);
            Assert.IsFalse(chainblock.Contains(transaction.Object));
        }

        [Test]
        public void GetAllInAmountRangeShouldReturnRightCollectionInRange()
        {
            Chainblock chainblock = new Chainblock();
            List<ITransaction> expectedResult = new List<ITransaction>();
            ITransaction transaction1 = new Transaction(1, TransactionStatus.Aborted, "Iva", "Borislav", 1);
            ITransaction transaction2 = new Transaction(11, TransactionStatus.Failed, "Iva", "Borislav", 2);
            ITransaction transaction3 = new Transaction(12, TransactionStatus.Successfull, "Iva", "Borislav", 300);
            ITransaction transaction4 = new Transaction(13, TransactionStatus.Unauthorized, "Iva", "Borislav", 400);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);

            expectedResult.Add(transaction3);
            expectedResult.Add(transaction4);
            var result = chainblock.GetAllInAmountRange(300, 400);
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldReturnRightCollection()
        {
            Chainblock chainblock = new Chainblock();
            List<ITransaction> expectedResult = new List<ITransaction>();
            ITransaction transaction1 = new Transaction(1, TransactionStatus.Aborted, "Iva", "Borislav", 100);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Failed, "Iva", "Borislav", 200);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "Iva", "Borislav", 300);
            ITransaction transaction4 = new Transaction(4, TransactionStatus.Unauthorized, "Iva", "Borislav", 200);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);

            expectedResult.Add(transaction3);
            expectedResult.Add(transaction2);
            expectedResult.Add(transaction4);
            expectedResult.Add(transaction1);

            var result = chainblock.GetAllOrderedByAmountDescendingThenById();
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusShouldReturnRightCollection()
        {
            Chainblock chainblock = new Chainblock();
            List<string> expectedResult = new List<string>();
            ITransaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "Iva", "Borislav", 100);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "Iva", "Stoqn", 200);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "Iva", "Niki", 300);
            ITransaction transaction4 = new Transaction(4, TransactionStatus.Unauthorized, "Iva", "Stanislava", 200);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);

            expectedResult.Add(transaction1.To);
            expectedResult.Add(transaction2.To);
            expectedResult.Add(transaction3.To);

            List<string> result = chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull).ToList();
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusShouldThrowInvalidOperationException()
        {
            Chainblock chainblock = new Chainblock();
            Assert.Throws<InvalidOperationException>
                (() => chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Aborted));
        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldReturnRightCollection()
        {
            Chainblock chainblock = new Chainblock();
            List<string> expectedResult = new List<string>();
            ITransaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "Iva", "Borislav", 100);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "Kondyo", "Borislav", 200);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "Rigan", "Borislav", 300);
            ITransaction transaction4 = new Transaction(4, TransactionStatus.Unauthorized, "Stoqn", "Borislav", 200);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);

            expectedResult.Add(transaction1.From);
            expectedResult.Add(transaction2.From);
            expectedResult.Add(transaction3.From);

            List<string> result = chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull).ToList();
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldThrowInvalidOperationException()
        {
            Chainblock chainblock = new Chainblock();
            Assert.Throws<InvalidOperationException>
                (() => chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Aborted));
        }

        [Test]
        public void GetByReceiverAndAmountRangeShouldReturnRightCollection()
        {
            Chainblock chainblock = new Chainblock();
            List<ITransaction> expectedResult = new List<ITransaction>();
            ITransaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "Iva", "Borislav", 100);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "Kondyo", "Borislav", 199);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "Rigan", "Borislav", 300);
            ITransaction transaction4 = new Transaction(4, TransactionStatus.Unauthorized, "Stoqn", "Borislav", 200);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);

            expectedResult.Add(transaction2);
            expectedResult.Add(transaction1);

            List<ITransaction> result = chainblock.GetByReceiverAndAmountRange("Borislav", 100, 200).ToList();
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void GetByRecieverAndAmauntRangeShouldThrowInvalidOperationException()
        {
            Chainblock chainblock = new Chainblock();
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverAndAmountRange("Stoqn", 144 , 455));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldReturnRightCollection()
        {
            Chainblock chainblock = new Chainblock();
            List<ITransaction> expectedResult = new List<ITransaction>();
            ITransaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "Iva", "Borislav", 100);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "Kondyo", "Borislav", 200);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "Rigan", "Borislav", 300);
            ITransaction transaction4 = new Transaction(4, TransactionStatus.Unauthorized, "Stoqn", "Borislav", 200);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);

            expectedResult.Add(transaction3);
            expectedResult.Add(transaction2);
            expectedResult.Add(transaction4);
            expectedResult.Add(transaction1);

            List<ITransaction> result = chainblock.GetByReceiverOrderedByAmountThenById("Borislav").ToList();
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldThrowInvalidOperationException()
        {
            Chainblock chainblock = new Chainblock();
            Assert.Throws<InvalidOperationException>
                (() => chainblock.GetByReceiverOrderedByAmountThenById("Dimitar"));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldReturnRightCollection()
        {
            Chainblock chainblock = new Chainblock();
            List<ITransaction> expectedResult = new List<ITransaction>();
            ITransaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "Iva", "Borislav", 100);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "Iva", "Borislav", 200);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "Rigan", "Borislav", 300);
            ITransaction transaction4 = new Transaction(4, TransactionStatus.Unauthorized, "Stoqn", "Borislav", 200);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);

            expectedResult.Add(transaction2);

            List<ITransaction> result = chainblock.GetBySenderAndMinimumAmountDescending("Iva", 100).ToList();
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldThrowInvalidOperationException()
        {
            Chainblock chainblock = new Chainblock();
            Assert.Throws<InvalidOperationException>
                (() => chainblock.GetBySenderAndMinimumAmountDescending("Iva", 144));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldReturnRightCollection()
        {
            Chainblock chainblock = new Chainblock();
            List<ITransaction> expectedResult = new List<ITransaction>();
            ITransaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "Iva", "Borislav", 100);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "Iva", "Borislav", 200);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "Rigan", "Borislav", 300);
            ITransaction transaction4 = new Transaction(4, TransactionStatus.Unauthorized, "Stoqn", "Borislav", 200);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);

            expectedResult.Add(transaction2);
            expectedResult.Add(transaction1);

            List<ITransaction> result = chainblock.GetBySenderOrderedByAmountDescending("Iva").ToList();
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void GetBySenderOrderByAmountDescendingShouldThrowInvalidOperationException()
        {
            Chainblock chainblock = new Chainblock();
            Assert.Throws<InvalidOperationException>
                (() => chainblock.GetBySenderOrderedByAmountDescending("Iva"));
        }

        [Test]
        public void GetByTransactionStatusShouldReturnRightCollection()
        {
            Chainblock chainblock = new Chainblock();
            List<ITransaction> expectedResult = new List<ITransaction>();
            ITransaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "Iva", "Borislav", 100);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "Iva", "Borislav", 200);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "Rigan", "Borislav", 300);
            ITransaction transaction4 = new Transaction(4, TransactionStatus.Unauthorized, "Stoqn", "Borislav", 200);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);

            expectedResult.Add(transaction3);
            expectedResult.Add(transaction2);
            expectedResult.Add(transaction1);

            List<ITransaction> result = chainblock.GetByTransactionStatus(TransactionStatus.Successfull).ToList();
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void GetByTransactionStatusShouldThrowInvalidOperationException()
        {
            Chainblock chainblock = new Chainblock();
            Assert.Throws<InvalidOperationException>
                (() => chainblock.GetByTransactionStatus(TransactionStatus.Aborted));
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldReturnRightCollection()
        {
            Chainblock chainblock = new Chainblock();
            List<ITransaction> expectedResult = new List<ITransaction>();
            ITransaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "Iva", "Borislav", 100);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "Iva", "Borislav", 200);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "Rigan", "Borislav", 300);
            ITransaction transaction4 = new Transaction(4, TransactionStatus.Unauthorized, "Stoqn", "Borislav", 200);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);

            expectedResult.Add(transaction2);
            expectedResult.Add(transaction1);

            List<ITransaction> result = chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 200).ToList();
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void RemoveTransactionByIdShouldDeleteTransaction()
        {
            Chainblock chainblock = new Chainblock();
            List<ITransaction> expectedResult = new List<ITransaction>();
            ITransaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "Iva", "Borislav", 100);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "Iva", "Borislav", 200);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "Rigan", "Borislav", 300);
            ITransaction transaction4 = new Transaction(4, TransactionStatus.Unauthorized, "Stoqn", "Borislav", 200);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);

            chainblock.RemoveTransactionById(4);

            bool transactionExist = false;

            foreach (var transaction in chainblock)
            {
                if (transaction.Id == 4)
                {
                    transactionExist = true;
                }
            }

            Assert.IsFalse(transactionExist);
        }

        [Test]
        public void RemoveTransactionByIdShouldThrowInvalidOperationException()
        {
            Chainblock chainblock = new Chainblock();
            Assert.Throws<InvalidOperationException>
                (() => chainblock.RemoveTransactionById(1));
        }
    }
}
