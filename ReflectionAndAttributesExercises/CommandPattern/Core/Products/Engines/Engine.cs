using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern.Core.Products.Engines
{
    public class Engine : IEngine
    {

        private  ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter commandInterpreter)
        {
            CommandInterpreter = commandInterpreter;
        }

        public ICommandInterpreter CommandInterpreter
        {
            get => commandInterpreter;
            private set => commandInterpreter = value;
        }

        public void Run()
        {
            while (true)
            {
                List<string> input = Console.ReadLine().Split().ToList();

                try
                {
                    Console.WriteLine(CommandInterpreter.Read(input.ToArray()));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
