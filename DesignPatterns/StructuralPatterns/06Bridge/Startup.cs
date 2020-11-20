namespace Bridge
{
    public class Startup
    {
        public static void Main()
        {
            IMessageSender text = new TextSender();
            IMessageSender web = new WebServiceSender();

            Message message = new SystemMessage();
            message.Subject = "A Message";
            message.Body = "Hi there, Please accept this message.";

            message.MessageSender = text;
            message.Send();

            message.MessageSender = web;
            message.Send();
        }
    }
}