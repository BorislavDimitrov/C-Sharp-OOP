using System;
using System.Collections.Generic;
using System.Text;

namespace People
{
    public class Person
    {
        private int age;
        private string name;
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            if (age < 0 )
            {
                throw new Exception();
            }
            this.Age = age;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {this.Name}, Age: {this.Age}");
            return sb.ToString();
        }
    }
}
