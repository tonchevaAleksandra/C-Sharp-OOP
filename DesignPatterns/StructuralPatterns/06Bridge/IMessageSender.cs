namespace Bridge
{
    public interface IMessageSender
    {
        void SendMessage(string subject, string body);
    }
}