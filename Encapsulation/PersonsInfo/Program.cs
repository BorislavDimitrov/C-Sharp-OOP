using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int personsNum = int.Parse(Console.ReadLine());
            Team team = new Team("igra4ite");

            for (int i = 0; i < personsNum; i++)
            {
                List<string> info = Console.ReadLine().Split().ToList();
                string firstName = info[0];
                string lastName = info[1];
                int age = int.Parse(info[2]);
                decimal salary = decimal.Parse(info[3]);
                Person person = new Person(firstName, lastName, age, salary);
                team.AddPlayer(person);
            }
            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
            

        }
    }
}
