using System;
using Vehicles.Core;
using Vehicles.IO.Contracts;
using Vehicles.IO.Models;

namespace Vehicles
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
