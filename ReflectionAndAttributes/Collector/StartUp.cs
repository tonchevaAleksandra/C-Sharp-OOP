using System;

namespace Collector
{
    [Author("Ventsi")]
  public  class StartUp
    {
        [Author("Gosho")]
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            Console.WriteLine(spy.RevealGetterAndSetterMethods("Hacker"));
        }
    }
}
