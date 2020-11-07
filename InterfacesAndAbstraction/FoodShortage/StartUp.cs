using FoodShortage.Core;

namespace FoodShortage
{
  public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
