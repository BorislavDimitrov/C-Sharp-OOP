using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Food : Product
    {
        private double grams;
        public virtual double Grams { get => grams; set => grams = value; }

        public Food(string name, decimal price, double grams) : base(name, price)
        {
            this.Grams = grams;
        }
    }
}
