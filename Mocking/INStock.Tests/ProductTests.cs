namespace INStock.Tests
{
    using INStock.Products;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void ConstructorShouldMakeRightProduct()
        {
            IProduct product = new Product("asdfghjklq", 14.99M, 10);
            Assert.AreEqual("asdfghjklq", product.Label);
            Assert.AreEqual(14.99M, product.Price);
            Assert.AreEqual(10, product.Quantity);
        }

        [Test]
        [TestCase("aslq", 14.99, 10)]
        [TestCase("asdfghjklq", 0, 10)]
        [TestCase("asdfghjklq", 0.11, -1)]
        public void ConstructorShouldThrowArgumentException
            (string label, decimal price, int quantity)
        {
            Assert.Throws<ArgumentException>(() => new Product(label, price, quantity));
        }
    }
}