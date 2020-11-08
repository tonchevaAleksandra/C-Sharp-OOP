using System;
using ExplicitInterfaces.IO.Contracts;

namespace ExplicitInterfaces.IO.Models
{
    public class ConsoleReader : IReadable
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
