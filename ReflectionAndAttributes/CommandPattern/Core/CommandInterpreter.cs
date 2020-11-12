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

            //object[] constructorArgs = new object[2]
            //   ICommand commandInstance = (ICommand)Activator.CreateInstance(commandType, constructorArgs);
            //  { "Asd", 12 }; -this is usefull when we have to create an instance by a concrete constructor

            //ConstructorInfo constructor = commandType
            //    .GetConstructors()
            //    .FirstOrDefault(c => c.GetParameters().Length == 0);
            //object[] ctorArgs = new object[] { };
            //ICommand commandInstance = (ICommand)constructor.Invoke(ctorArgs);
            //this will return the constror to that instance with 0 parameters

            ICommand commandInstance = (ICommand)Activator.CreateInstance(commandType);

            string result = commandInstance.Execute(commandArgs);
 
            return result;

        }
    }
}
