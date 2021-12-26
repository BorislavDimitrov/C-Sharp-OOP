using System;

namespace SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            try
            {
                number = int.Parse(Console.ReadLine());
                if (number <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                double result = Math.Sqrt(number);
                Console.WriteLine(result);

            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Invalid number");
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Invalid number");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Goodbye");
            }
        }
    }
}
