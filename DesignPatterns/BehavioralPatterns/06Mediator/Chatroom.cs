using System.Collections.Generic;

namespace Mediator
{
    public class Chatroom : AbstractChatroom
    {
        private Dictionary<string, Participant> participants;

        public Chatroom()
        {
            this.participants = new Dictionary<string, Participant>();
        }

        public override void Register(Participant participant)
        {
            if (!this.participants.ContainsValue(participant))
            {
                this.participants[participant.Name] = participant;
            }

            participant.Chatroom = this;
        }

        public override void Send(string from, string to, string message)
        {
            Participant participant = this.participants[to];

            if (participant != null)
            {
                participant.Receive(from, message);
            }
        }
    }
}