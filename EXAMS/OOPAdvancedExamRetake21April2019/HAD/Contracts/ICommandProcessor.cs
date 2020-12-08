using System.Collections.Generic;

namespace HAD.Contracts
{
    public interface ICommandProcessor
    {
        string Process(IList<string> arguments);
    }
}