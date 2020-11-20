using System;

namespace Memento
{
    public class Originator
    {
        private string state;

        public string State
        {
            get => this.state;
            set
            {
                this.state = value;

                Console.WriteLine("State = " + state);
            }
        }

        public Memento CreateMemento()
        {
            return new Memento(state);
        }

        public void SetMemento(Memento memento)
        {
            Console.WriteLine("Restoring state...");

            this.State = memento.State;
        }
    }
}