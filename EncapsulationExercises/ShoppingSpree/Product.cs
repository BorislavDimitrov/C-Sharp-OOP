using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private double cost;

        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
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
                catch 
                {
                    Console.WriteLine("Name cannot be empty");
                    Environment.Exit(0);
                }
            }
        }

        public double Cost
        {
            get => cost;
            private set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new Exception();
                    }
                    cost = value;
                }
                catch 
                {
                    Console.WriteLine("Money cannot be negative");
                    Environment.Exit(0);
                }
            }
        }

    }
}
