using System;

namespace CustomException
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student student1 = new Student("Ivan Ivanov", "ivan@abv.bg");
            }
            catch (StudentInvalidFormatInput ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Student student2 = new Student("IvaN" , "IIVANvan53352@abv.bg");
            }
            catch (StudentInvalidFormatInput ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Student student3 = new Student("Georgi Stamev" , "georg1@abv.bg2");
            }
            catch (StudentInvalidFormatInput ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
