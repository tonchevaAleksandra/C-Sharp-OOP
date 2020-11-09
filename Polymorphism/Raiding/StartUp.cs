using Raiding.Core;
using Raiding.IO;
using Raiding.IO.Contracts;

namespace Raiding
{
   public  class StartUp
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
