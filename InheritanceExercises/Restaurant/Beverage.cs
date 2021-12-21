using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price, double milliliters) : base(name, price)
        {
            this.Milliliters = milliliters;
        }

        private double milliliters;
        public virtual double Milliliters { get => milliliters; set => milliliters = value; }
    }
}
