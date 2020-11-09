using System;

using WildFarm.IO.Contracts;

namespace WildFarm.Models.IO
{
    public class ConsoleReader : IReadable
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
