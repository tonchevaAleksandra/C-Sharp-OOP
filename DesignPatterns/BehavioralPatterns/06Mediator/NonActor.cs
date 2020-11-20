using System;

namespace Mediator
{
    public class NonActor : Participant
    {
        public NonActor(string name)
            : base(name)
        { }

        public override void Receive(string from, string message)
        {
            Console.Write("To a non-Actor: ");
           
            base.Receive(from, message);
        }
    }
}