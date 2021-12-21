using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }
        public string FirstName 
        { get => firstName;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain than 3 symbols!");
                }

                firstName = value;
            }
        }
        public string LastName 
        { get => LastName;
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain than 3 symbols!");
                }

                lastName = value;
            }
        }
        public int Age 
        { get => age; 
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }

                age = value;
            } 
        }
        public decimal Salary 
        { get => salary;
            private set
            {
                if (value < 460)
                {
                    throw new ArgumentException("Salary cannot be less than 650 leva!");
                }

                salary = value;
            } 
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age < 30)
            {
                this.Salary += this.Salary * percentage / 200;
            }
            else
            {
                this.Salary += this.Salary * percentage / 100;
            }
        } 

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
        }
    }
}
