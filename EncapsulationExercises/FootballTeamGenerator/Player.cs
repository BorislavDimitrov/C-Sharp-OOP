using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
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
        public int Endurance 
        { get => endurance;
            private set
            {
                Validation(value, nameof(Endurance));
                endurance = value;
            }
        }
        public int Sprint 
        { 
            get => sprint; 
            private set
            {
                Validation(value, nameof(Sprint));
                sprint = value;
            }
        }
        public int Dribble 
        { 
            get => dribble; 
            private set
            {
                Validation(value, nameof(Dribble));
                dribble = value;
            }
        }
        public int Passing 
        { 
            get => passing;
            private set
            {
                Validation(value, nameof(Passing));
                passing = value;
            } 
        }
        public int Shooting 
        { 
            get => shooting; 
            private set
            {
                Validation(value, nameof(Shooting));
                shooting = value;
            }
        }

        public double GetSkillLevel()
        {
            return (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0;
        }

        private void Validation(int value, string valueName)
        {
            if (value < 0 || value > 100)
            {
            throw new ArgumentException($"{valueName} should be between 0 and 100.");
            }
        }
    }
}
