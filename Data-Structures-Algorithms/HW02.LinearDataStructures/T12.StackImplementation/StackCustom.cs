namespace T12.StackImplementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class StackCustom<T>
    {
        private const int DefaultCapacity = 4;
        private T[] stackArray;

        public StackCustom()
        {
            this.StackArray = new T[DefaultCapacity];
            this.Count = 0;
        }

        public StackCustom(int capacity = DefaultCapacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity can't be null");
            }

            this.StackArray = new T[capacity];
            this.Count = 0;
        }

        public StackCustom(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection), "Collection can't be null");
            }

            var newCollection = collection as ICollection<T>;

            if (newCollection != null)
            {
                int count = newCollection.Count;
                this.StackArray = new T[count];
                newCollection.CopyTo(this.StackArray, 0);
                this.Count = count;
                return;
            }

            this.Count = 0;
            this.StackArray = new T[DefaultCapacity];

            using (var enumerator = collection.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    this.Push(enumerator.Current);
                }
            }
        }

        public T[] StackArray
        {
            get { return this.stackArray; }
            set { this.stackArray = value; }
        }

        public int Count { get; private set; }

        public void Clear()
        {
            Array.Clear(this.StackArray, 0, this.Count);
            this.Count = 0;
        }

        public bool Contains(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Value can't be null");
            }

            return this.StackArray.Contains(item);
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
                throw new ArgumentException("Value is out range");
            }

            Array.Copy(this.StackArray, 0, array, index, this.Count);
            Array.Reverse(array, index, this.Count);
        }

        public void TrimExcess()
        {
            int num = (int)(this.StackArray.Length * 0.9d);

            if (this.Count >= num)
            {
                return;
            }

            T[] array = new T[this.Count];
            Array.Copy(this.StackArray, 0, array, 0, this.Count);
            this.StackArray = array;
        }

        public T Peak()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Count is 0");
            }

            return this.StackArray[this.Count - 1];
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Empty array");
            }

            var result = this.StackArray[--this.Count];
            this.StackArray[this.Count] = default(T);
            return result;
        }

        public void Push(T item)
        {
            if (this.Count == this.StackArray.Length)
            {
                var capacity = 0;

                if (this.StackArray.Length == 0)
                {
                    capacity = DefaultCapacity;
                }
                else
                {
                    capacity = 2 * this.StackArray.Length;
                }

                T[] array = new T[capacity];
                Array.Copy(this.StackArray, 0, array, 0, this.Count);
                this.StackArray = array;
            }

            this.StackArray[this.Count++] = item;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                array[i] = this.StackArray[this.Count - i - 1];
            }

            return array;
        }
    }
}
