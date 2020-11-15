using System;
using System.Collections.Generic;
using System.Text;

namespace DependancyInjectionPractice
{
    public class ConsoleIntroducer : IIntroducable
    {
        public void Introduce(string message)
        {
            Console.WriteLine(message);
        }
    }
}
