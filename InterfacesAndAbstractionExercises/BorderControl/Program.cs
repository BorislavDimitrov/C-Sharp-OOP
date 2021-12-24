using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentify> crossedBorder = new List<IIdentify>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                List<string> info = input.Split(" " , StringSplitOptions.RemoveEmptyEntries).ToList();

                if (info.Count == 3)
                {
                    string citizenName = info[0];
                    int citizenAge = int.Parse(info[1]);
                    string citizenId = info[2];
                    IIdentify newCitizen = new Citizen(citizenName, citizenAge, citizenId);

                    crossedBorder.Add(newCitizen);
                }
                else if (info.Count == 2)
                {
                    string robotModel = info[0];
                    string robotId = info[1];
                    IIdentify newRobot = new Robot(robotModel, robotId);
                    crossedBorder.Add(newRobot);
                }
            }

            string specificIdNumber = Console.ReadLine();
            List<string> detainedIds = new List<string>();

            foreach (var crossed in crossedBorder)
            {
                if (crossed.Id.EndsWith(specificIdNumber) == true)
                {
                    detainedIds.Add(crossed.Id);
                }
            }

            foreach (var id in detainedIds)
            {
                Console.WriteLine(id);
            }
        }
    }
}
