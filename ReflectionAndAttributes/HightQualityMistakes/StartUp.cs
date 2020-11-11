using System;

namespace HightQualityMistakes
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            var result = spy.AnalyzeAcessModifiers("Hacker");
            Console.WriteLine(result);
        }
    }
}
