using INStock.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace INStock.Stocks
{
    public interface IStock
    {
        public void Add(IProduct productToAdd);
        public bool Contains(IProduct productToSearch);
        public int Count();
        public IProduct Find(int index);
        public IProduct FindByLebel(string label);
        public IEnumerable<IProduct> FindAllInPriceRange(decimal minPrice, decimal maxPrice);
        public IEnumerable<IProduct> FindAllByPrice(decimal price);
        public IEnumerable<IProduct> FindMostExpensiveProduct(int count);
        public IEnumerable<IProduct> FindAllByQuantity(int quantity);
        public IEnumerable<IProduct> GetEnumerator();

    }
}
