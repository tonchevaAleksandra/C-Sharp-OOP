using System;
using Raiding.IO.Contracts;

namespace Raiding.IO
{
    public class ConsoleReader : IReadable
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
