using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Fish : MainDish
    {
        private const double FishGrams = 22;
        public Fish(string name, decimal price, double grams = FishGrams)
            : base(name, price, grams)
        {
            
        }
    }
}
