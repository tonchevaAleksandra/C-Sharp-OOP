namespace Interpreter
{
    public class Context
    {
        // Constructor
        public Context(string input)
        {
            this.Input = input;
        }

        public string Input { get; set; }

        public int Output { get; set; }
    }
}