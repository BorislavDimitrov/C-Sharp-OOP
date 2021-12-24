using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BirthdayCelebrations
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthdays = new List<IBirthable>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                List<string> info = input.Split(" " , StringSplitOptions.RemoveEmptyEntries).ToList();
                string type = info[0];

                if (type == "Citizen")
                {
                    string citizenName = info[1];
                    int citizenAge = int.Parse(info[2]);
                    string id = info[3];
                    DateTime birthdate = DateTime.ParseExact(info[4] , "d/M/yyyy", CultureInfo.InvariantCulture);
                    IBirthable citizen = new Citizen(citizenName, citizenAge, id, birthdate);
                    birthdays.Add(citizen);
                }
                else if (type == "Pet")
                {
                    string petName = info[1];
                    DateTime birthdate = DateTime.ParseExact(info[2] , "d/M/yyyy" , CultureInfo.InvariantCulture );
                    IBirthable pet = new Pet(petName, birthdate);
                    birthdays.Add(pet);
                }
            }

            int specificYear = int.Parse(Console.ReadLine());
            List<DateTime> specificDates = new List<DateTime>();

            foreach (var birthdate in birthdays)
            {
                if (birthdate.Birthdate.Year == specificYear)
                {
                    specificDates.Add(birthdate.Birthdate);
                };
            }

            foreach (var date in specificDates)
            {
                Console.WriteLine(date.ToString("dd/MM/yyyy"));
            }
        }
    }
}
