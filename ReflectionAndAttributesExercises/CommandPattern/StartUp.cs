using CommandPattern.Core.Contracts;
using CommandPattern.Core.Products.Engines;
using CommandPattern.Core.Products.Interpreters;
using System;

namespace CommandPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);
            engine.Run();
        }
    }
}
