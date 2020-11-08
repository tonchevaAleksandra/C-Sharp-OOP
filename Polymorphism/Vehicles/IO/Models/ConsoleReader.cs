using System;
using Vehicles.IO.Contracts;

namespace Vehicles.IO.Models
{
    public class ConsoleReader : IReadable
    {
        public string ReadLine()=> Console.ReadLine();
        
    }
}
