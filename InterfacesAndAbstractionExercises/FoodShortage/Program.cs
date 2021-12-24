using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                List<string> info = Console.ReadLine().Split().ToList();

                if (info.Count == 4)
                {
                    string citizenName = info[0];
                    int age = int.Parse(info[1]);
                    string id = info[2];
                    DateTime birthday = DateTime.ParseExact(info[3], "d/M/yyyy" , CultureInfo.InvariantCulture);
                    IBuyer newCitizen = new Citizen(citizenName, age, id, birthday);
                    buyers.Add(newCitizen);
                }
                else if (info.Count == 3)
                {
                    string rebelName = info[0];
                    int age = int.Parse(info[1]);
                    string group = info[2];
                    IBuyer newRebel = new Rebel(rebelName, age, group);
                    buyers.Add(newRebel);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                List<string> names = input.Split(" " , StringSplitOptions.RemoveEmptyEntries).ToList();

                if (names.Count > 1)
                {
                    continue;
                }

                foreach (var buyer in buyers)
                {
                    if (buyer.Name == names[0])
                    {
                        buyer.BuyFood();
                    }
                }
            }

            int totalFood = 0;

            foreach (var buyer in buyers)
            {
                totalFood += buyer.Food;
            }

            Console.WriteLine(totalFood);
        }
    }
}
