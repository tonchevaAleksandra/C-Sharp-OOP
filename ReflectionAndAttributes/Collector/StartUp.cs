using System;

namespace Collector
{
  public  class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            Console.WriteLine(spy.RevealGetterAndSetterMethods("Hacker"));
        }
    }
}
