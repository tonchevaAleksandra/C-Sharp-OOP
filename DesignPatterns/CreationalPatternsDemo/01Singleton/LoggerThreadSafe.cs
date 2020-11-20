namespace Singleton
{
    public class LoggerThreadSafe
    {
        private static LoggerThreadSafe instance;
        private static readonly object padlock = new object();

        private LoggerThreadSafe()
        {
        }

        public static LoggerThreadSafe Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new LoggerThreadSafe();
                    }

                    return instance;
                }
            }
        }
    }
}