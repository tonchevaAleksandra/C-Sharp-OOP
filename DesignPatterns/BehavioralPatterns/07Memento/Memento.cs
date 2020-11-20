namespace Memento
{
    public class Memento
    {
        public Memento(string state)
        {
            this.State = state;
        }

        public string State { get; }
    }
}