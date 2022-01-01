using CommandPattern.Core.Contracts;
using CommandPattern.Core.Products.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core.Products.Interpreters
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string[] args)
        {
            string commandName = args[0] + "Command";
            string[] arguments = args.Skip(1).ToArray();

            var type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => x.Name == commandName)
                .FirstOrDefault();

            if (type == null)
            {
                throw new InvalidOperationException("Invalid command");
            }
            ICommand instance = (ICommand)Activator.CreateInstance(type);
            string result = instance.Execute(arguments);

            return result;

           // Made without reflection
           // ICommand newCommand = null;
           // if (commandName == nameof(HelloCommand))
           // {
           //     newCommand = new HelloCommand();
           // }
           // else if (commandName == nameof(ExitCommand))
           // {
           //     newCommand = new ExitCommand();
           // }
           // else
           // {
           //     throw new ArgumentException("Invalid command");
           // }
           //
           // return newCommand.Execute(arguments);
        }
    }
}
