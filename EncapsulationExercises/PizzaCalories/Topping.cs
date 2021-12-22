using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private Dictionary<string, double> typeCalories = new Dictionary<string, double>
        {
            {"meat", 1.2},
            {"veggies", 0.8},
            {"cheese", 1.1},
            {"sauce", 0.9}
        };
        private const double BaseModifier = 2;
        private string type;
        private double grams;

        public Topping(string type, double grams)
        {
            this.Type = type;
            this.Grams = grams;          
        }

        private string Type
        {
            get => type;
            set
            {
                try
                {
                    if (!typeCalories.ContainsKey(value.ToLower()))
                    {
                        throw new Exception();
                    }
                    type = value;
                }
                catch 
                {
                    Console.WriteLine($"Cannot place {value} on top of your pizza.");
                    Environment.Exit(0);
                }
            }
        }

        private double Grams
        {
            get => grams;
            set
            {
                try
                {
                    if (value < 1 || value > 50)
                    {
                        throw new Exception();
                    }
                    grams = value;
                }
                catch 
                {
                    Console.WriteLine($"{this.type} weight should be in range [1..50].");
                    Environment.Exit(0);
                }
            }
        }

        public double CalculateCalories ()
        {
            return Grams * BaseModifier * typeCalories[this.type.ToLower()];
        }
    }
}
