using System;
using Vehicles.IO.Contracts;

namespace Vehicles.IO.Models
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
