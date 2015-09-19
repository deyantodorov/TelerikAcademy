using System;

namespace MementoPattern
{
    public class Originator<T>
    {
        private T state;

        //for saving the state
        public Memento<T> CreateMemento()
        {
            var memento = new Memento<T>();
            memento.SetState(this.state);
            return memento;
        }

        //for restoring the state
        public void SetMemento(Memento<T> memento)
        {
            this.state = memento.GetState();
        }

        //change the state of the Originator
        public void SetState(T setState)
        {
            this.state = setState;
        }

        //show the state of the Originator
        public void ShowState()
        {
            Console.WriteLine(this.state.ToString());
        }
    }
}
