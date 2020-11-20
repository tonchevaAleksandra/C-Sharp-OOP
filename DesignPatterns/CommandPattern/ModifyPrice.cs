using System.Collections.Generic;

using CommandPattern.Contracts;

namespace CommandPattern
{
    public class ModifyPrice
    {
        private readonly List<ICommand> _commands;
        private ICommand _command;

        public ModifyPrice()
        {
            this._commands = new List<ICommand>();
        }

        public void SetCommamd(ICommand command) => this._command = command;

        public void Invoke()
        {
            this._commands.Add(this._command);
            this._command.ExecuteAction();
        }
    }
}
