using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.IO.Contracts;

namespace MilitaryElite.IO.Models
{
    public class ConsoleWriter : IWriter
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
