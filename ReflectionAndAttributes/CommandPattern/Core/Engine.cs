using System;

using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            while (true)
            {
                string args = Console.ReadLine();

                try
                {
                    string result = this.commandInterpreter.Read(args);
                    Console.WriteLine(result);
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
                
            }
        }
    }
}
