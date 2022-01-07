using System;
using System.Collections.Generic;
using System.Text;

namespace INStock.Products
{
    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int quantity;
        public Product(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }
        public string Label
        {
            get => label;
            private set
            {
                if (value.Length < 10)
                {
                    throw new ArgumentException();
                }
                label = value;
            }
        }

        public decimal Price
        {
            get => price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                price = value;
            }
        }

        public int Quantity
        {
            get => quantity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                quantity = value;
            }
        }
    }
}
