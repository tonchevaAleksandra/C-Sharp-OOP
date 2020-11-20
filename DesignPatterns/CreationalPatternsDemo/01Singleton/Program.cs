namespace Singleton
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = Logger.Instance;
            var secondLogger = Logger.Instance;

            System.Console.WriteLine(logger.GetHashCode() == secondLogger.GetHashCode());
        }
    }
}