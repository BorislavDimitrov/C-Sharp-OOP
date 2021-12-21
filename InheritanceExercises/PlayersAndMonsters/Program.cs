using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            BladeKnight knight = new BladeKnight("Igracha" , 52);
            Console.WriteLine(knight.ToString());
        }
    }
}
