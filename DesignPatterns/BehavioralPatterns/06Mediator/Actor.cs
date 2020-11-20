using System;

namespace Mediator
{
    public class Actor : Participant
    {
        public Actor(string name)
            : base(name)
        { }

        public override void Receive(string from, string message)
        {
            Console.Write("To an Actor: ");
            
            base.Receive(from, message);
        }
    }
}