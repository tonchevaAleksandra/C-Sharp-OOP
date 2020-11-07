
using System;
using MilitaryElite.IO.Contracts;

namespace MilitaryElite.IO.Models
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
           return Console.ReadLine();
        }
    }
}
