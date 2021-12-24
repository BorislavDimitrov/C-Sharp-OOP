using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<Private> privates;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, params Private[] privates)
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<Private>();
            foreach (var privateSoldier in privates)
            {
                this.privates.Add(privateSoldier);
            }
        }

        public IReadOnlyCollection<Private> Privates { get => privates; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
            sb.Append("Privates:");
            if (privates.Count > 0)
            {
                sb.Append("\n");
                sb.Append("  ");
                sb.Append($"{string.Join("\n  ", privates)}");
            }
            return sb.ToString();
        }
    }
}
