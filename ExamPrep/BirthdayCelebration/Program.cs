using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> peopleInfo = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> platesInfo = Console.ReadLine().Split().Select(int.Parse).ToList();
            Queue<int> people = new Queue<int>(peopleInfo);
            Stack<int> plates = new Stack<int>(platesInfo);
            int wastedFood = 0;

            while (people.Count > 0 && plates.Count > 0)
            {
                int currentPerson = people.Peek();

                while (currentPerson > 0 && plates.Count > 0)
                {
                    int currPlate = plates.Pop();
                    currentPerson -= currPlate;
                    if (currentPerson == 0)
                    {
                        people.Dequeue();
                    }
                    else if (currentPerson <0)
                    {
                        wastedFood += Math.Abs(currentPerson);
                        people.Dequeue();
                    }
                }
            }

            if (people.Count == 0)
            {
                Console.WriteLine($"Plates: {string.Join(" " , plates)}");
                Console.WriteLine($"Wasted grams of food: {wastedFood}");
            }
            else if (plates.Count == 0)
            {
                Console.WriteLine($"Guests: {string.Join(" " , people)}");
                Console.WriteLine($"Wasted grams of food: {wastedFood}");
            }
        }
    }
}
