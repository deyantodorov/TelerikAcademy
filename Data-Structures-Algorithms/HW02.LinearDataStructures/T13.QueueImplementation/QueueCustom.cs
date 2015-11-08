namespace T13.QueueImplementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class QueueCustom<T> : IEnumerable<T>
    {
        private readonly LinkedList<T> elements = new LinkedList<T>();

        public int Count
        {
            get { return this.elements.Count; }
        }

        public void Enqueue(T value)
        {
            this.elements.AddLast(value);
        }

        public T Peek()
        {
            this.ValidateCountMoreThenZero();
            return this.elements.First.Value;
        }

        public T Dequeue()
        {
            this.ValidateCountMoreThenZero();

            T value = this.elements.First.Value;
            this.elements.RemoveFirst();

            return value;
        }

        public void Clear()
        {
            this.elements.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void ValidateCountMoreThenZero()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("QueueCustom is empty");
            }
        }
    }
}
