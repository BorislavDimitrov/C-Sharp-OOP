using System;
using System.Collections.Generic;
using System.Linq;

namespace ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                List<string> citizenInfo = input.Split().ToList();
                string citizenName = citizenInfo[0];
                string country = citizenInfo[1];
                int age = int.Parse(citizenInfo[2]);
                IPerson newPerson = new Citizen(citizenName, country, age);
                newPerson.GetName();
                IResident newResident = new Citizen(citizenName, country, age);
                newResident.GetName();
            }
        }
    }
}
