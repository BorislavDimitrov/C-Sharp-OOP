using System;

namespace FixingVol2
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber, secondNumber;
            byte result;

            firstNumber = 60;
            secondNumber = 30;
            try
            {
                result = Convert.ToByte(firstNumber * secondNumber);
                Console.WriteLine($"{firstNumber} * {secondNumber} = {result}");
            }
            catch (OverflowException ex)
            {
                short realResult = (short)(firstNumber * secondNumber);
                Console.WriteLine($"{firstNumber} * {secondNumber} = {realResult}");

            }
        }
    }
}
