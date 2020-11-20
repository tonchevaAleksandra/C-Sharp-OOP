using System;

namespace Bridge
{
    public class TextSender : IMessageSender
    {
        public void SendMessage(string subject, string body)
        {
            string messageType = "Text";
         
            Console.WriteLine($"{messageType}");
            Console.WriteLine("--------------");
            Console.WriteLine($"Subject:  {subject} from {messageType}");
            Console.WriteLine($"Body:  {body}");
            Console.WriteLine();
        }
    }
}