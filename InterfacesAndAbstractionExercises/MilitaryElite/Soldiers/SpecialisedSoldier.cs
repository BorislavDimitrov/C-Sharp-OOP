using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class SpecialisedSoldier : Private
    {
        private string corp;

        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corp)
            : base(id, firstName, lastName, salary)
        {
            this.Corp = corp;
        }

        public string Corp 
        { 
            get => corp; 
            private set
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new ArgumentException();
                }
                corp = value;
            }
        }
    }
}
