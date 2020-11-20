namespace Memento
{
    public class Startup
    {
        public static void Main()
        {
            Originator o = new Originator();

            o.State = "On";

            Caretaker c = new Caretaker();

            c.Memento = o.CreateMemento();
            o.State = "Off";
            o.SetMemento(c.Memento);
        }
    }
}