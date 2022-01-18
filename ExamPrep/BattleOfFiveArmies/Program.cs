using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleOfFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armyArmor = int.Parse(Console.ReadLine());
            int matrixN = int.Parse(Console.ReadLine());
            char[][] battleField = new char[matrixN][];
            int currRow = 0;
            int currCol = 0;

            for (int row = 0; row < battleField.GetLength(0); row++)
            {
                string line = Console.ReadLine();
                battleField[row] = new char[line.Length];
                for (int col = 0; col < line.Length; col++)
                {
                    if (line[col] == 'A')
                    {
                        currRow = row;
                        currCol = col;
                    }
                    battleField[row][col] = line[col];
                }
            }

            while (true)
            {
                List<string> input = Console.ReadLine().Split(" " , StringSplitOptions.RemoveEmptyEntries).ToList();
                string command = input[0];
                int orcRow = int.Parse(input[1]);
                int orcCol = int.Parse(input[2]);
                battleField[orcRow][orcCol] = 'O';
                armyArmor--;
                bool isInside = false;

                if (command == "up" && currRow - 1 >= 0)
                {
                    isInside = true;
                    battleField[currRow][currCol] = '-';
                    currRow--;
                }
                else if (command == "down" && currRow + 1 <= battleField.Length - 1)
                {
                    isInside = true;
                    battleField[currRow][currCol] = '-';
                    currRow++;
                }
                else if (command == "left" && currCol - 1 >= 0)
                {
                    isInside = true;
                    battleField[currRow][currCol] = '-';
                    currCol--;
                }
                else if (command == "right" && currCol + 1 <= battleField[currRow].Length - 1)
                {
                    isInside = true;
                    battleField[currRow][currCol] = '-';
                    currCol++;
                }

                if (!isInside)
                {
                    continue;
                }

                if (battleField[currRow][currCol] == 'O' )
                {
                    armyArmor -= 2;

                    if (armyArmor <= 0)
                    {
                        battleField[currRow][currCol] = 'X';
                        Console.WriteLine($"The army was defeated at {currRow};{currCol}.");
                        break;
                    }
                }
                else if (battleField[currRow][currCol] == 'M')
                {
                    battleField[currRow][currCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmor}");
                    break;
                }

                battleField[currRow][currCol] = 'A';
            }

            for (int row = 0; row < battleField.Length; row++)
            {
                for (int col = 0; col < battleField[row].Length; col++)
                {
                    Console.Write($"{battleField[row ][ col]}");
                }
                Console.WriteLine();
            }
            
        }
    }
}
