namespace T11.LinkedList
{
    public sealed class ListNode<T>
    {
        private ListNode<T> next;
        private ListNode<T> prev;
        private LinkedList<T> list;
        private T value;

        public ListNode(T value)
        {
            this.Value = value;
        }

        public ListNode(LinkedList<T> list, T value)
            : this(value)
        {
            this.List = list;
        }

        public LinkedList<T> List
        {
            get { return this.list; }
            set { this.list = value; }
        }

        public ListNode<T> Next
        {
            get
            {
                if (this.next != null && this.next != this.list.Head)
                {
                    return this.next;
                }

                return null;
            }

            set { this.next = value; }
        }

        public ListNode<T> Previous
        {
            get
            {
                if (this.prev != null && this.prev != this.list.Head)
                {
                    return this.prev;
                }

                return null;
            }

            set { this.prev = value; }
        }

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public void Invalidate()
        {
            this.list = null;
            this.next = null;
            this.prev = null;
        }
    }
}
