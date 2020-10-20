
using StudentSystem.Entities;

namespace StudentSystem
{
   public class Engine
    {
        private StudentData studentData;
        private IInputOutputProvider inputOutputProvider;
        public Engine(StudentData studentData, IInputOutputProvider inputOutputProvider)
        {
            this.studentData = new StudentData();
            this.inputOutputProvider = inputOutputProvider;
        }
        public void Process()
        {
            var end = false;
            while (!end)
            {
                var line = this.inputOutputProvider.GetInput();

                end = ExecuteCommand(line);
            }
        }

        private bool ExecuteCommand(string line)
        {
            var command = Command.Parse(line);
            var arguments = command.Arguments;
            switch (command.Name)
            {
                case "Create":
                    this.studentData.Add(arguments[0], int.Parse(arguments[1]), double.Parse(arguments[2]));
                    break;
                case "Show":
                    var details = this.studentData.GetDetails(arguments[0]);
                    this.inputOutputProvider.ShowOutput(details);
                    break;
                case "Exit":
                    return true;

            }

            return false;
        }

    }
}
