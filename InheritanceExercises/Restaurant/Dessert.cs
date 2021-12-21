using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Dessert : Food
    {
        private double calories;
        public virtual double Calories { get => calories; set => calories = value; }
        public Dessert(string name, decimal price, double grams, double calories) 
            : base(name, price, grams)
        {
            this.Calories = calories;
        }
    }
}
