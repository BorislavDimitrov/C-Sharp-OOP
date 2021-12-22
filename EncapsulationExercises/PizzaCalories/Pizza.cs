using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }

        public Dough Dough { set => dough = value; }
        public string Name 
        {   get => name; 
            private set
            {
                try
                {
                    if (value == " " || value == string.Empty || value.Length > 15)
                    {
                        throw new Exception();
                    }
                    name = value;
                }
                catch (Exception)
                {
                    Console.WriteLine("Pizza name should be between 1 and 15 symbols.");
                    Environment.Exit(0);
                }
            }
        }

        public int NumberOfToppings { get => toppings.Count; }

        public void AddTopping(Topping topping)
        {
            try
            {
                if (toppings.Count == 10)
                {
                    throw new Exception();
                }
                toppings.Add(topping);
            }
            catch 
            {
                Console.WriteLine("Number of toppings should be in range [0..10].");
                Environment.Exit(0);
            }
        }

        public double TotalCalories
        {
            get
            {
                double totalCalories = 0;
                totalCalories += dough.CalculateCalories();

                foreach (var topping in toppings)
                {
                    totalCalories += topping.CalculateCalories();
                }
                return totalCalories;
            }
        }
    }
}
