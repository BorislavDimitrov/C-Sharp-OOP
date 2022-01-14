using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterChef
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input1 = Console.ReadLine().Split().Select(int.Parse).ToList();           
            List<int> input2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            Queue<int> ingredients = new Queue<int>(input1);
            Stack<int> freshnessValues = new Stack<int>(input2);

            int dippingSauce = 0;
            int greenSalad = 0;
            int chocolateCake = 0;
            int lobster = 0;

            while (ingredients.Count > 0 && freshnessValues.Count > 0)
            {
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }

                int freshnessLevel = ingredients.Peek() * freshnessValues.Pop();

                if (freshnessLevel == 150)
                {
                    ingredients.Dequeue();
                    dippingSauce++;
                }
                else if (freshnessLevel == 250)
                {
                    ingredients.Dequeue();
                    greenSalad++;
                }
                else if (freshnessLevel == 300)
                {
                    ingredients.Dequeue();
                    chocolateCake++;
                }
                else if (freshnessLevel == 400)
                {
                    ingredients.Dequeue();
                    lobster++;
                }
                else 
                {
                    int currIngre = ingredients.Dequeue() + 5;
                    ingredients.Enqueue(currIngre);
                }
            }

            if (dippingSauce > 0 && greenSalad > 0 && lobster > 0 && chocolateCake > 0)
            {
                Console.WriteLine($"Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine("Ingredients left: " + ingredients.Sum());
            }

            Dictionary<string, int> dishes = new Dictionary<string, int>();
            dishes.Add("Dipping sauce" , dippingSauce);
            dishes.Add("Green salad" , greenSalad);
            dishes.Add("Chocolate cake" , chocolateCake);
            dishes.Add("Lobster" , lobster);
            dishes = dishes.OrderBy(x => x.Key).ToDictionary(x => x.Key , y => y.Value);

            foreach (var dish in dishes)
            {
                if (dish.Value > 0)
                {
                    Console.WriteLine($" # {dish.Key} --> {dish.Value}");
                }
            }
        }
    }
}
