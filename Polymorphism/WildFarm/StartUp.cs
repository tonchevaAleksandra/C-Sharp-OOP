
using WildFarm.Core;
using WildFarm.Models.IO;
using WildFarm.IO.Contracts;

namespace WildFarm
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            IReadable reader = new ConsoleReader();
            IWritable writer = new ConsoleWriter();

            Engine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
