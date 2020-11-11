using Logger.Models.Enumerations;

namespace Logger.Models.Contracts
{
   public interface IAppender
    {
        ILayout Layout { get; }
        Level Level { get; }
        long MessagesAppended { get; }
        void Append(IError error);
    }
}
