using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                List<string> info = input.Split(";" , StringSplitOptions.RemoveEmptyEntries).ToList();
                string command = info[0];
                string teamName = info[1];
                try
                {
                    if (command == "Team")
                    {
                        Team newTeam = new Team(teamName);
                        teams.Add(newTeam);
                    }
                    else if (command == "Add")
                    {
                        Team teamToAdd = teams.FirstOrDefault(x => x.Name == teamName);
                        if (teamToAdd == null)
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }

                        string playerName = info[2];
                        int endurance = int.Parse(info[3]);
                        int sprint = int.Parse(info[4]);
                        int dribble = int.Parse(info[5]);
                        int passing = int.Parse(info[6]);
                        int shooting = int.Parse(info[7]);
                        Player newPlayer = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        teamToAdd.AddPlayer(newPlayer);
                    }
                    else if (command == "Remove")
                    {
                        string playerName = info[2];
                        teams.First(x => x.Name == teamName).RemovePlayer(playerName);
                    }
                    else if (command == "Rating")
                    {
                        Team teamToRate = teams.FirstOrDefault(x => x.Name == teamName);

                        if (teamToRate == null)
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }

                        Console.WriteLine($"{teamToRate.Name} - {teamToRate.Rating}");
                    }
                }
                 catch (Exception ex)
                 {
                     Console.WriteLine(ex.Message);                  
                 }
               
                }
            }
        }
  }

