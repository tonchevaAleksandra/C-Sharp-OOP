using System;

namespace Prototype
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SandwichMenu menu = new SandwichMenu();

            menu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Letuce, Tomato");
            menu["PB&J"] = new Sandwich("White", "", "", "Peanut Butter, Jelly");

            Sandwich bitSandwich = menu["BLT"].Clone() as Sandwich;

            Sandwich pbjSandwich1 = menu["PB&J"].Clone() as Sandwich;

            Sandwich pbjSandwich2 = menu["PB&J"].Clone() as Sandwich;
        }
    }
}
