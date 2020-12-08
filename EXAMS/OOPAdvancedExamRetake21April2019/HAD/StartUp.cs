using HAD.Contracts;
using HAD.Core;
using HAD.IO;

namespace HAD
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IManager manager = new HeroManager();
            ICommandProcessor commandProcessor = new CommandProcessor(manager);
            var engine = new Engine(reader, writer, commandProcessor);
            engine.Run();
        }
    }
}
