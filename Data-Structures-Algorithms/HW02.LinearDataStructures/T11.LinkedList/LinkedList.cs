namespace T11.LinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
    {
        public LinkedList()
        {
        }

        public LinkedList(IEnumerable<T> collection)
            : base()
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Provided collection cann't be null");
            }

            foreach (T current in collection)
            {
                this.AddLast(current);
            }
        }

        public int Count { get; set; }

        public ListNode<T> Head { get; set; }

        public ListNode<T> First
        {
            get { return this.Head; }
        }

        public ListNode<T> Last
        {
            get
            {
                if (this.Head != null)
                {
                    return this.Head.Previous;
                }

                return null;
            }
        }

        public ListNode<T> AddAfter(ListNode<T> node, T value)
        {
            this.ValidateNode(node);
            var listNode = new ListNode<T>(node.List, value);
            this.InternalInsertNodeBefore(node.Next, listNode);
            return listNode;
        }

        public void AddAfter(ListNode<T> node, ListNode<T> newNode)
        {
            this.ValidateNode(node);
            this.ValidateNode(newNode);
            this.InternalInsertNodeBefore(node.Next, newNode);
            newNode.List = this;
        }

        public ListNode<T> AddBefore(ListNode<T> node, T value)
        {
            this.ValidateNode(node);
            var listNode = new ListNode<T>(node.List, value);
            this.InternalInsertNodeBefore(node, listNode);
            if (node == this.Head)
            {
                this.Head = listNode;
            }

            return listNode;
        }

        public void AddBefore(ListNode<T> node, ListNode<T> newNode)
        {
            this.ValidateNode(node);
            this.ValidateNode(newNode);
            this.InternalInsertNodeBefore(node, newNode);
            newNode.List = this;
            if (node == this.Head)
            {
                this.Head = newNode;
            }
        }

        public ListNode<T> AddFirst(T value)
        {
            var listNode = new ListNode<T>(this, value);
            if (this.Head == null)
            {
                this.InternalInsertNodeToEmptyList(listNode);
            }
            else
            {
                this.InternalInsertNodeBefore(this.Head, listNode);
                this.Head = listNode;
            }

            return listNode;
        }

        public void AddFirst(ListNode<T> node)
        {
            this.ValidateNode(node);
            if (this.Head == null)
            {
                this.InternalInsertNodeToEmptyList(node);
            }
            else
            {
                this.InternalInsertNodeBefore(this.Head, node);
                this.Head = node;
            }

            node.List = this;
        }

        public ListNode<T> AddLast(T value)
        {
            var listNode = new ListNode<T>(this, value);
            if (this.Head == null)
            {
                this.InternalInsertNodeToEmptyList(listNode);
            }
            else
            {
                this.InternalInsertNodeBefore(this.Head, listNode);
            }

            return listNode;
        }

        public void AddLast(ListNode<T> node)
        {
            this.ValidateNode(node);
            if (this.Head == null)
            {
                this.InternalInsertNodeToEmptyList(node);
            }
            else
            {
                this.InternalInsertNodeBefore(this.Head, node);
            }

            node.List = this;
        }

        public void Clear()
        {
            var next = this.Head;

            while (next != null)
            {
                var listNode = next;
                next = next.Next;
                listNode.Invalidate();
            }

            this.Head = null;
            this.Count = 0;
        }

        public bool Contains(T value)
        {
            return this.Find(value) != null;
        }

        public void CopyTo(T[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Array can't be null");
            }

            if (index < 0 || index > array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
            }

            if (array.Length - index < this.Count)
            {
                throw new ArgumentException("Insufficient space");
            }

            var next = this.Head;
            if (next == null)
            {
                return;
            }

            do
            {
                array[index++] = next.Value;
                next = next.Next;
            }
            while (next != this.Head);
        }

        public ListNode<T> Find(T value)
        {
            var next = this.Head;

            if (next == null)
            {
                return null;
            }

            while (next.Value != null)
            {
                next = next.Next;
                if (next == this.Head)
                {
                    return null;
                }
            }

            return next;
        }

        public ListNode<T> FindLast(T value)
        {
            if (this.Head == null)
            {
                return null;
            }

            var prev = this.Head.Previous;
            var listNode = prev;

            if (listNode == null)
            {
                return null;
            }

            while (listNode.Value != null)
            {
                listNode = listNode.Previous;
                if (listNode == prev)
                {
                    return null;
                }
            }

            return listNode;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.Head;

            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool Remove(T value)
        {
            var listNode = this.Find(value);

            if (listNode == null)
            {
                return false;
            }

            this.InternalRemoveNode(listNode);
            return true;
        }

        public void Remove(ListNode<T> node)
        {
            this.ValidateNode(node);
            this.InternalRemoveNode(node);
        }

        public void RemoveFirst()
        {
            if (this.Head == null)
            {
                throw new InvalidOperationException("Linked list is empty");
            }

            this.InternalRemoveNode(this.Head);
        }

        public void RemoveLast()
        {
            if (this.Head == null)
            {
                throw new InvalidOperationException("Linked list is empty");
            }

            this.InternalRemoveNode(this.Head.Previous);
        }

        private void InternalRemoveNode(ListNode<T> node)
        {
            if (node.Next == node)
            {
                this.Head = null;
            }
            else
            {
                node.Next.Previous = node.Previous;
                node.Previous.Next = node.Next;
                if (this.Head == node)
                {
                    this.Head = node.Next;
                }
            }

            node.Invalidate();
            this.Count--;
        }

        private void ValidateNode(ListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "Node can't be null");
            }

            if (node.List != this)
            {
                throw new InvalidOperationException("External ListNode");
            }
        }
        
        private void InternalInsertNodeToEmptyList(ListNode<T> newNode)
        {
            newNode.Next = newNode;
            newNode.Previous = newNode;
            this.Head = newNode;
            this.Count++;
        }

        private void InternalInsertNodeBefore(ListNode<T> node, ListNode<T> newNode)
        {
            newNode.Next = node;
            newNode.Previous = node.Previous;
            node.Previous.Next = newNode;
            node.Previous = newNode;
            this.Count++;
        }
    }
}