using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            players = new List<Player>();
        }

        public string Name 
        {
            get => name; 
            private set
            {
               if (string.IsNullOrWhiteSpace(value))
               {
                   throw new ArgumentException("A name should not be empty.");
               }
                name = value;
            }
        }
        private IReadOnlyCollection<Player> Players { get => players.AsReadOnly(); }

        public int Rating
        {
            get
            {
                double totalPlayersStat = players.Sum(x => x.GetSkillLevel());
                if (players.Count == 0)
                {
                    return 0;
                }
                return (int)Math.Round((totalPlayersStat / players.Count));
            }
        }

        public void AddPlayer(Player playerToAdd)
        {
              players.Add(playerToAdd);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = players.FirstOrDefault(x => x.Name == playerName);
            if ( player == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {Name} team.");
            }

            players.Remove(players.First(x => x.Name == playerName));
        }
    }
}
