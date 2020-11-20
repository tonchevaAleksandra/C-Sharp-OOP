namespace Mediator
{
    public class Startup
    {
        static void Main()
        {
            Chatroom chatroom = new Chatroom();

            Participant Eddie = new Actor("Eddie");
            Participant Jennifer = new Actor("Jennifer");
            Participant Bruce = new Actor("Bruce");
            Participant Tom = new Actor("Tom");
            Participant Tony = new NonActor("Tony");

            chatroom.Register(Eddie);
            chatroom.Register(Jennifer);
            chatroom.Register(Bruce);
            chatroom.Register(Tom);
            chatroom.Register(Tony);

            Tony.Send("Tom", "Hey Tom! I got a mission for you.");
            Jennifer.Send("Bruce", "Teach me to act and I'll" +
                " teach you to dance");
            Bruce.Send("Eddie", "How come you don't do standup anymore?");

            Jennifer.Send("Tom", "Do you like math?");
            Tom.Send("Tony", "Teach me to sing.");
        }
    }
}
