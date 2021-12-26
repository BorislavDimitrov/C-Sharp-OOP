using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ValidPerson
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName 
        { 
            get => firstName; 
            set
            {
                Regex nameValidationRegex = new Regex(@"^[A-Z][a-z]+$");
                if (!nameValidationRegex.IsMatch(value))
                {
                    throw new FormatException("Name format is not valid");
                }
                firstName = value;
            } 
        }
        public string LastName 
        { 
            get => lastName;
            set
            {
                Regex nameValidationRegex = new Regex(@"^[A-Z][a-z]+$");
                if (!nameValidationRegex.IsMatch(value))
                {
                    throw new FormatException("Name format is not valid");
                }
                lastName = value;
            } 
        }
        public int Age 
        { 
            get => age;
            set
            {
                if (value <= 0 || value > 150)
                {
                    throw new ArgumentOutOfRangeException("Age cannot be negative or more than 150 years");
                }
                age = value;
            }
        }
    }
}
