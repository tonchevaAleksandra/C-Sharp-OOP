using System;
using ExplicitInterfaces.IO.Contracts;

namespace ExplicitInterfaces.IO.Models
{
    public class ConsoleWriter : IWritable
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
