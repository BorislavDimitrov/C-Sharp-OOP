using INStock.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INStock.Stocks
{
    public class Stock : IStock
    {
        private List<IProduct> products;
        public Stock()
        {
            products = new List<IProduct>();
        }

        public void Add(IProduct productToAdd)
        {
            products.Add(productToAdd);
        }

        public bool Contains(IProduct productToSearch)
        {
            IProduct searchedProduct = products.FirstOrDefault(x => x == productToSearch);
            if (searchedProduct != null)
            {
                return true;
            }

            return false;
        }

        public int Count() => products.Count;
        
        public IProduct Find(int index)
        {
            if (index > products.Count - 1)
            {
                throw new IndexOutOfRangeException();
            }

            IProduct product = products[index];
                 
            return product;
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            IEnumerable<IProduct> searchedProdcuts = products.Where(x => x.Price == price);
            return searchedProdcuts;
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            IEnumerable<IProduct> searchedProducts = products.Where(x => x.Quantity == quantity);
            return searchedProducts;
        }

        public IEnumerable<IProduct> FindAllInPriceRange(decimal minPrice, decimal maxPrice)
        {
            IEnumerable<IProduct> searchedProducts = products.Where(x => x.Price >= minPrice && x.Price <= maxPrice);
            return searchedProducts;
        }

        public IProduct FindByLebel(string label)
        {
            IProduct searchedProduct = products.FirstOrDefault(x => x.Label == label);

            if (searchedProduct == null)
            {
                throw new ArgumentException();
            }

            return searchedProduct;
        }

        public IEnumerable<IProduct> FindMostExpensiveProduct(int count)
        {
            List<IProduct> sortedByPriceProducts = products.OrderByDescending(x => x.Price).ToList();
            IEnumerable<IProduct> searchedProducts = sortedByPriceProducts.Take(count);
            return searchedProducts;
        }

        public IEnumerable<IProduct> GetEnumerator() => products;
    }
}
