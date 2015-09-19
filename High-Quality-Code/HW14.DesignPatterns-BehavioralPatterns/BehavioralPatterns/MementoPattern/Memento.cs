namespace MementoPattern
{
    public class Memento<T>
    {
        private T state;

        public T GetState()
        {
            return this.state;
        }

        public void SetState(T state)
        {
            this.state = state;
        }
    }
}
