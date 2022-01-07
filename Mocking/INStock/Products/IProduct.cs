using System;
using System.Collections.Generic;
using System.Text;

namespace INStock.Products
{
    public interface IProduct
    {
        public int Quantity { get; }
        public string  Label { get; }
        public decimal Price { get; }
    }
}
