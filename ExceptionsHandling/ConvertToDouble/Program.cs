using System;

namespace ConvertToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = 0;

            try
            {
                number = Convert.ToDouble(Console.ReadLine());
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Number too big for Convert.ToDouble");
                throw;
            }
            catch (FormatException )
            {
                Console.WriteLine("Cant Convert.ToDouble that input format");
                throw;
            }
            Console.WriteLine(number);
        }
    }
}
