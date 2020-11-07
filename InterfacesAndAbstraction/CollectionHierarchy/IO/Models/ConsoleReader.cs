using System;
using CollectionHierarchy.IO.Contracts;

namespace CollectionHierarchy.IO.Models
{
    public class ConsoleReader : IReadable
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
