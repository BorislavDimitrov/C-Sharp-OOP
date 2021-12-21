using System;
using System.Collections.Generic;
using System.Text;

namespace People
{
    public class Children : Person
    {
        public Children(string name ,int age) : base(name , age)
        {
            this.Name = name;
            if (age > 15)
            {
                throw new Exception();
            }
            this.Age = age;
        }
    }
}
