﻿namespace CounterStrike
{
    using CounterStrike.Core;
    using CounterStrike.Core.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
