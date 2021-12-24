using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier
    {
        private List<Mission> missions;

        public Commando(string id, string firstName, string lastName, decimal salary, string corp, params Mission[] missions) 
            : base(id, firstName, lastName, salary, corp)
        {
            this.missions = new List<Mission>();
            foreach (var mission in missions)
            {
                this.missions.Add(mission);
            }
        }

        public IReadOnlyCollection<Mission> Missions 
        {
            get => missions;
        }

        public void CompleteMission(string missionName)
        {
            missions.First(x => x.CodeName == missionName).State = "Finished";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
            sb.AppendLine($"Corps: {this.Corp}");
            sb.Append("Missions:");
            if (missions.Count > 0)
            {
                sb.Append("\n");
                sb.Append("  ");
                sb.Append($"{string.Join("\n  ", missions)}");
            }
            return sb.ToString();
        }
    }
}
