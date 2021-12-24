using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : SpecialisedSoldier
    {
        private List<Repair> repairs;

        public Engineer(string id, string firstName, string lastName, decimal salary, string corp, params Repair[] repairs) 
            : base(id, firstName, lastName, salary, corp)
        {
            this.repairs = new List<Repair>();
            foreach (var repair in repairs)
            {
                this.repairs.Add(repair);
            }
        }

        public IReadOnlyCollection<Repair> Repairs 
        {
            get => repairs;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
            sb.AppendLine($"Corps: {this.Corp}");
            sb.Append("Repairs:");
            if (repairs.Count > 0)
            {
                sb.Append("\n");
                sb.Append("  ");
                sb.Append($"{string.Join("\n  ", repairs)}");
            }
            return sb.ToString();
        }
    }
}
