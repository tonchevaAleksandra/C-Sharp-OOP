

namespace StudentSystem
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var studentData = new StudentData();
            var inputOutputProvider = new ConsoleInputOutputProvider();

            var engine = new Engine(studentData, inputOutputProvider);

            engine.Process();

        }
    }
}
