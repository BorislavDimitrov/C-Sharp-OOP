namespace INStock.Tests
{
    using INStock.Products;
    using INStock.Stocks;
    using NUnit.Framework;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    [TestFixture]
    public class ProductStockTests
    {
        [Test]
        public void ConstructorShouldMakeEmptyStock()
        {
            IStock stock = new Stock();
            Assert.AreEqual(0, stock.Count());
        }

        [Test]
        public void AddShouldAddProducts()
        {
            IStock stock = new Stock();
            var products = new List<IProduct>();
            var product1 = new Product("gergergergerger", 14.57M, 1);
            stock.Add(product1);
            products.Add(product1);
            var product2 = new Product("vbnxmbvcbg", 77.87M, 10);
            products.Add(product2);
            stock.Add(product2);
            Assert.AreEqual(products, stock.GetEnumerator());
        }

        [Test]
        public void ContainsShouldReturnTrue()
        {
            IStock stock = new Stock();
            IProduct product = new Product("asdfghjklq", 10.54M, 5);
            stock.Add(product);
            Assert.IsTrue(stock.Contains(product));
        }

        [Test]
        public void ContainsShouldReturnFalse()
        {
            IStock stock = new Stock();
            IProduct product1 = new Product("asdfghjklq", 10.54M, 5);
            stock.Add(product1);
            IProduct product2 = new Product("asdfghjklq", 10.54M, 5);
            Assert.IsFalse(stock.Contains(product2));
        }

        [Test]
        public void FindShouldReturnProductByGivenIndex()
        {
            IStock stock = new Stock();
            IProduct product1 = new Product("aertrnrhjklq", 10.87M, 5);
            IProduct product2 = new Product("asergeghjklq", 15.54M, 5);
            IProduct product3 = new Product("abbbffghjklq", 2.5M, 5);
            stock.Add(product1);
            stock.Add(product2);
            stock.Add(product3);
            IProduct productResult = stock.Find(2);
            Assert.AreEqual(productResult, product3);
        }

        [Test]
        public void FindShouldThrowIndexOutOfRangeException()
        {
            IStock stock = new Stock();
            IProduct product1 = new Product("aertrnrhjklq", 10.87M, 5);
            IProduct product2 = new Product("asergeghjklq", 15.54M, 5);
            IProduct product3 = new Product("abbbffghjklq", 2.5M, 5);
            stock.Add(product1);
            stock.Add(product2);
            stock.Add(product3);
            Assert.Throws<IndexOutOfRangeException>(() => stock.Find(3));        
        }

        [Test]
        public void FindAllByPriceShouldReturnRightProducts()
        {
            IStock stock = new Stock();
            List<IProduct> products = new List<IProduct>();
            IProduct product1 = new Product("aertrnrhjklq", 15.54M, 5);
            IProduct product2 = new Product("asergeghjklq", 15.54M, 5);
            IProduct product3 = new Product("abbbffghjklq", 2.5M, 5);
            stock.Add(product1);
            stock.Add(product2);
            stock.Add(product3);
            products.Add(product1);
            products.Add(product2);
            IEnumerable<IProduct> result = stock.FindAllByPrice(15.54M);
            CollectionAssert.AreEqual(products, result);
        }

        [Test]
        public void FindAllByPriceShouldReturnEmptyCollection()
        {
            IStock stock = new Stock();
            List<IProduct> products = new List<IProduct>();
            IEnumerable<IProduct> result = stock.FindAllByPrice(15.54M);
            CollectionAssert.AreEqual(products, result);
        }

        [Test]
        public void FindAllByQuantityShouldReturnRightProducts()
        {
            IStock stock = new Stock();
            List<IProduct> products = new List<IProduct>();
            IProduct product1 = new Product("aertrnrhjklq", 15.54M, 5);
            IProduct product2 = new Product("asergeghjklq", 15.54M, 5);
            IProduct product3 = new Product("abbbffghjklq", 2.5M, 5);
            stock.Add(product1);
            stock.Add(product2);
            stock.Add(product3);
            products.Add(product1);
            products.Add(product2);
            products.Add(product3);
            IEnumerable<IProduct> result = stock.FindAllByQuantity(5);
            CollectionAssert.AreEqual(products, result);
        }

        [Test]
        public void FindAllByQuantityShouldReturnEmptyCollection()
        {
            IStock stock = new Stock();
            List<IProduct> products = new List<IProduct>();
            IEnumerable<IProduct> result = stock.FindAllByQuantity(5);
            CollectionAssert.AreEqual(products, result);
        }

        [Test]
        public void FindAllByPriceRangeShouldReturnRightCollection()
        {
            IStock stock = new Stock();
            List<IProduct> products = new List<IProduct>();
            IProduct product1 = new Product("aertrnrhjklq", 15.54M, 5);
            IProduct product2 = new Product("asergeghjklq", 15.54M, 5);
            IProduct product3 = new Product("abbbffghjklq", 2.5M, 5);
            stock.Add(product1);
            stock.Add(product2);
            stock.Add(product3);
            products.Add(product1);
            products.Add(product2);
            products.Add(product3);
            IEnumerable<IProduct> result = stock.FindAllInPriceRange(2.5M, 15.54M);
            CollectionAssert.AreEqual(products, result);
        }

        [Test]
        public void FindAllByPriceRangeShouldReturnEmptyCollection()
        {
            IStock stock = new Stock();
            List<IProduct> products = new List<IProduct>();
            IEnumerable<IProduct> result = stock.FindAllInPriceRange(5.1M, 10.4M);
            CollectionAssert.AreEqual(products, result);
        }

        [Test]
        public void FindByLebelShouldReturnRightProduct()
        {
            IStock stock = new Stock();
            List<IProduct> products = new List<IProduct>();
            IProduct product1 = new Product("aertrnrhjklq", 15.54M, 5);
            IProduct product2 = new Product("asergeghjklq", 15.54M, 5);
            IProduct product3 = new Product("abbbffghjklq", 2.5M, 5);
            stock.Add(product1);
            stock.Add(product2);
            stock.Add(product3);
            IProduct result = stock.FindByLebel("aertrnrhjklq");
            Assert.AreEqual(product1, result);
        }

        [Test]
        public void FindByLebelShouldThrowArgumentException()
        {
            IStock stock = new Stock();
            List<IProduct> products = new List<IProduct>();
            IProduct product1 = new Product("aertrnrhjklq", 15.54M, 5);
            IProduct product2 = new Product("asergeghjklq", 15.54M, 5);
            IProduct product3 = new Product("abbbffghjklq", 2.5M, 5);
            stock.Add(product1);
            stock.Add(product2);
            stock.Add(product3);
            Assert.Throws < ArgumentException>(() => stock.FindByLebel("e345345345345345gerg"));
        }

        [Test]
        public void FindMostExpensiveProductShouldReturnRightCollection()
        {
            IStock stock = new Stock();
            List<IProduct> sortedProducts = new List<IProduct>();
            IProduct product1 = new Product("aaaaaaaaaaaa", 13.54M, 5);
            IProduct product2 = new Product("asergeghjklq", 14.54M, 5);
            IProduct product3 = new Product("abbbffghjklq", 15.5M, 5);
            IProduct product4 = new Product("abbbffghjklq", 3.5M, 5);
            IProduct product5 = new Product("abbbffghjklq", 2.5M, 5);
            stock.Add(product5);
            stock.Add(product3);
            stock.Add(product2);
            stock.Add(product4);
            stock.Add(product1);
            sortedProducts.Add(product3);
            sortedProducts.Add(product2);
            sortedProducts.Add(product1);
            sortedProducts.Add(product4);
            sortedProducts.Add(product5);
            var result = stock.FindMostExpensiveProduct(5);
            CollectionAssert.AreEqual(sortedProducts, result);
        }
    }
}
