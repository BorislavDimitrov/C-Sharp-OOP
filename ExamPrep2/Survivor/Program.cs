using System;
using System.Collections.Generic;
using System.Linq;

namespace Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsNum = int.Parse(Console.ReadLine());
            char[][] field = new char[rowsNum][];

            for (int i = 0; i < rowsNum; i++)
            {
                field[i] = Console.ReadLine().Split().Select(char.Parse).ToArray();
            }

            int myTokens = 0;
            int oponentTokens = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Gong")
                {
                    break;
                }

                List<string> info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                string command = info[0];
                int row = int.Parse(info[1]);
                int col = int.Parse(info[2]);
                string direction = string.Empty;

                if (info.Count == 4)
                {
                    direction = info[3];
                }

                if (command == "Find")
                {
                    if (row >= 0 && row < field.Length)
                    {
                        if (col >= 0 && col < field[row].Length)
                        {
                            if (field[row][col] == 'T')
                            {
                                myTokens++;
                                field[row][col] = '-';
                            }
                        }
                    }
                }
                else if (command == "Opponent")
                {
                    if (row >= 0 && row < field.Length)
                    {
                        if (col >= 0 && col < field[row].Length)
                        {
                            if (field[row][col] == 'T')
                            {
                                oponentTokens++;
                                field[row][col] = '-';

                                if (direction == "up")
                                {
                                    int moveCounter = 0;
                                    while (moveCounter < 3)
                                    {
                                        
                                        if (row - 1 >= 0)
                                        {
                                            
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
