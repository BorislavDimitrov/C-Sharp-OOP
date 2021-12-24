using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Spy : Soldier
    {
        public Spy(string id, string firstName, string lastName, int code) 
            : base(id, firstName, lastName)
        {
            this.Code = code;
        }

        public int Code { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");
            sb.Append($"Code Number: {this.Code}");
            return sb.ToString();
        }
    }
}
