using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> pizzaInfo = Console.ReadLine().Split().ToList();
            string pizzaName = pizzaInfo[1];
            Pizza pizza = new Pizza(pizzaName);

            List<string> doughInfo = Console.ReadLine().Split().ToList();
            string flourType = doughInfo[1];
            string bakingTechnique = doughInfo[2];
            double doughGrams = double.Parse(doughInfo[3]);
            Dough dough = new Dough(flourType, bakingTechnique, doughGrams);

            pizza.Dough = dough;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                List<string> toppingInfo = input.Split().ToList();
                string toppingType = toppingInfo[1];
                double toppingGrams = double.Parse(toppingInfo[2]);
                Topping topping = new Topping(toppingType, toppingGrams);

                pizza.AddTopping(topping);
            }

            Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories.");
        }
    }
}
