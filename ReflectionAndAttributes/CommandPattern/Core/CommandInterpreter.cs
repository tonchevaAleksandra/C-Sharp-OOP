using System;
using System.Linq;
using System.Reflection;

using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX = "Command";
        public CommandInterpreter()
        {

        }
        public string Read(string args)
        {
            string[] commandTokens = args.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string commandName = commandTokens[0] + COMMAND_POSTFIX;
            string[] commandArgs = commandTokens
                .Skip(1)
                .ToArray();

            //Get assembly in order to get types
            Assembly assembly = Assembly.GetCallingAssembly();

            //Get concrete command type in order to produce instance of the concrete command
            Type commandType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == commandName.ToLower());
            if(commandType==null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            //Create instance of concrete command in order  to invoke Execute()
            ICommand commandInstance = (ICommand)Activator.CreateInstance(commandType);

            string result = commandInstance.Execute(commandArgs);
 
            return result;

        }
    }
}
