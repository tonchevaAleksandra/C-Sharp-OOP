using System;

namespace DependancyInjectionPractice
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var introducer = new ConsoleIntroducer();
            var dragon = new Dragon("Drago", introducer);
            dragon.Introduce();
        }
    }
}
