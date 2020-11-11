using System;
using Logger.Models.Enumerations;

namespace Logger.Models.Contracts
{
   public interface IError
    {
        DateTime DateTime { get; }
        string Message { get; }

        Level Level { get; }
    }
}
