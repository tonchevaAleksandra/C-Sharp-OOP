using System.Collections.Generic;
using System.Linq;
using HAD.Contracts;

namespace HAD.Core
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly IManager heroManager;

        public CommandProcessor(IManager heroManager)
        {
            this.heroManager = heroManager;
        }

        public string Process(IList<string> arguments)
        {
            string command = arguments[0];
            arguments = arguments.Skip(1).ToList();

            string result = null;

            switch (command)
            {
                case "Hero":
                    result = this.heroManager.AddHero(arguments);
                    break;
                case "Item":
                    result = this.heroManager.AddItem(arguments);
                    break;
                case "Recipe":
                    result = this.heroManager.AddRecipe(arguments);
                    break;
                case "Inspect":
                    result = this.heroManager.Inspect(arguments);
                    break;
                case "Quit":
                    result = this.heroManager.Quit();
                    break;
            }

            //result = null;

            return result;
        }
    }
}