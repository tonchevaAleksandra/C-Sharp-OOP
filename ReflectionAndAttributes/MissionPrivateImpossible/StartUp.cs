using System;

namespace MissionPrivateImpossible
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            Console.WriteLine(spy.RevealPrivateMethods("Hacker"));
        }
    }
}
