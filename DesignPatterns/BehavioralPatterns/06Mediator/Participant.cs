using System;

namespace Mediator
{
    public class Participant
    {
        public Participant(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public Chatroom Chatroom { get; set; }

        public void Send(string to, string message)
        {
            this.Chatroom.Send(this.Name, to, message);
        }

        public virtual void Receive(string from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}'", from, Name, message);
        }
    }
}