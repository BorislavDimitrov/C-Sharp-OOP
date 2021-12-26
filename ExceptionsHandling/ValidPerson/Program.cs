using System;

namespace ValidPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person person1 = new Person("Ivan", "Draganov", 32);
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }

            try
            {
                Person person2 = new Person("Be", "he", 12);
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }

            try
            {
                Person person3 = new Person("Boris", "Dimitrov", 200);
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
        }
    }
}
