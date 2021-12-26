using System;
using System.Collections.Generic;

namespace EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 0;
            int end = 0;

            try
            {
                start = int.Parse(Console.ReadLine());
                if (start < 0 || start > 90)
                {
                    throw new ArgumentOutOfRangeException();
                }
                end = int.Parse(Console.ReadLine());
                if (end > 100 || end < 10)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid number");
                throw;
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Invalid number");
                throw;
            }
            catch
            {
                Console.WriteLine("Invalid number");
                throw;
            }

            ReadNumber(start, end);

        }

        public static void ReadNumber(int start, int end)
        {
            List<int> numbers = new List<int>();
            int lastNumber = start - 1;
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    int newNumber = int.Parse(Console.ReadLine());
                    if (newNumber < start || newNumber > end || lastNumber >= newNumber)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    lastNumber = newNumber;
                    numbers.Add(newNumber);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Invalid number entered , start entering numbers over again");
                    i = 0;
                    numbers.Clear();
                    lastNumber = start - 1;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Invalid number entered , start entering numbers over again");
                    i = 0;
                    numbers.Clear();
                    lastNumber = start - 1;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Invalid number entered , start entering numbers over again");
                    i = 0;
                    numbers.Clear();
                    lastNumber = start - 1;
                }
            }

            Console.WriteLine(string.Join(" " , numbers));
        }
    }    
}
