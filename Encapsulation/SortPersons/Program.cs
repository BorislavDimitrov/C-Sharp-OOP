using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            int peopleNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleNum; i++)
            {
                List<string> info = Console.ReadLine().Split().ToList();
                string firstName = info[0];
                string lastName = info[1];
                int age = int.Parse(info[2]);
                Person person = new Person(firstName, lastName, age);
                people.Add(person);
            }

            people.OrderBy(x => x.FirstName)
                .ThenBy(x => x.Age)
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));
        }
    }
}
