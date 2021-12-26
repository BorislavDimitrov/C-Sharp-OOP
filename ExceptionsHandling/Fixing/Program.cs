﻿using System;

namespace Fixing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] weekdays = new string[5];
            weekdays[0] = "Sunday";
            weekdays[1] = "Monday";
            weekdays[2] = "Tuesday";
            weekdays[3] = "Wednesday";
            weekdays[4] = "Thursday";

            try
            {
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine(weekdays[i].ToString());
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.Clear();
                for (int i = 0; i <= weekdays.Length - 1; i++)
                {
                    Console.WriteLine(weekdays[i].ToString());
                }
            }
        }
    }
}
