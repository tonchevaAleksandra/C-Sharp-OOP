using System.Collections.Generic;

namespace HAD.Contracts
{
    public interface IManager
    {
        string AddHero(IList<string> arguments);

        string AddItem(IList<string> arguments);

        string AddRecipe(IList<string> arguments);

        string Inspect(IList<string> arguments);

        string Quit();
    }
}