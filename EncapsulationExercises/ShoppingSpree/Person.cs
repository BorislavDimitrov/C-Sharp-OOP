using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;
        private List<Product> products;

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            products = new List<Product>();
        }

        public string Name
        {
            get => name;
            private set
            {
                try
                {
                    if (value == string.Empty || value == " ")
                    {
                        throw new Exception();
                    }
                    name = value;
                }
                catch (Exception)
                {
                    Console.WriteLine("Name cannot be empty");
                    Environment.Exit(0);
                }
            }
        }

        public double Money
        {
            get => money;
            private set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new Exception();
                    }
                    money = value;
                }
                catch 
                {
                    Console.WriteLine("Money cannot be negative");
                    Environment.Exit(0);
                }
            }
        }

        public IReadOnlyCollection<Product> Products 
        {
            get => products;
        }

        public void AddProduct(Product product)
        {
            money -= product.Cost;
            products.Add(product);
        }
    }
}
