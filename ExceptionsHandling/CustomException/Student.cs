using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CustomException
{
    public class Student
    {
        private string name;
        private string email;
        public Student(string name, string email)
        {
            Name = name;
            Email = email;
        }
        public string Name 
        {
            get => name;
            set
            {
                Regex nameValidate = new Regex(@"^([A-Z][a-z]+) ?([A-Z][a-z]+)?$");
                if (!nameValidate.IsMatch(value))
                {
                    throw new StudentInvalidFormatInput("Invalid name!");
                }
                name = value;
            }
        }
        public string Email 
        { 
            get => email;
            set
            {
                Regex emailValidate = new Regex(@"^[A-Za-z0-9]+@[a-z]{3,5}.[a-z]{2,3}$");
                if (!emailValidate.IsMatch(value))
                {
                    throw new StudentInvalidFormatInput("Invalid email!");
                }
                email = value;
            }
        }
    }
}
