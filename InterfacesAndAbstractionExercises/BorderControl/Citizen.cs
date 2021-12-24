using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace BorderControl
{
    public class Citizen : IIdentify
    {
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id {get ; set; }
    }
}
