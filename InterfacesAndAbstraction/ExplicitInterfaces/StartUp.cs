using ExplicitInterfaces.Core;
using ExplicitInterfaces.IO.Contracts;
using ExplicitInterfaces.IO.Models;

namespace ExplicitInterfaces
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
