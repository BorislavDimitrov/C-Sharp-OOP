using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Repair
    {
        public Repair(string name, int hoursWorked)
        {
            this.Name = name;
            this.HoursWorked = hoursWorked;
        }
        public string Name { get; set; }
        public int HoursWorked { get; set; }

        public override string ToString()
        {
            return $"Part Name: {this.Name} Hours Worked: {this.HoursWorked}";
        }
    }
}
