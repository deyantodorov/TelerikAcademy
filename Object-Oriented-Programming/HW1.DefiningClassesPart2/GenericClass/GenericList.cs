namespace GenericClass
{
    using System;
    using System.Text;

    /// <summary>
    /// Problem 5. Generic class
    ///            Write a generic class GenericList<T> that keeps a list of elements of some parametric type T.
    ///            Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor.
    ///            Implement methods for 
    ///            adding element, 
    ///            accessing element by index, 
    ///            removing element by index, 
    ///            inserting element at given position, 
    ///            clearing the list, 
    ///            finding element by its value 
    ///            and ToString().
    ///            Check all input parameters to avoid accessing elements at invalid positions.
    ///            
    /// Problem 6. Auto-grow
    ///            Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it.
    ///            
    /// Problem 7. Min and Max
    ///            Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the GenericList<T>.
    ///            You may need to add a generic constraints for the type T
    /// </summary>
    public class GenericList<T> where T : IComparable
    {
        private const int DefaultSize = 8;
        private T[] array;
        private int count;

        public GenericList(int size = DefaultSize)
        {
            this.ValidateInitialSize(size);
            this.array = new T[size];
        }

        public int Length
        {
            get
            {
                return this.array.Length;
            }
        }

        public T this[int position]
        {
            get
            {
                this.ValidateOutOfRange(position);
                return this.array[position];
            }

            set
            {
                this.ValidateOutOfRange(position);
                this.array[position] = value;
                this.count++;
            }
        }

        public void Add(T element)
        {
            if (this.count >= this.array.Length)
            {
                this.ResizeArray();

                this.array[this.count] = element;
                this.count++;
            }
            else
            {
                this.array[this.count] = element;
                this.count++;
            }
        }

        public void RemoveAt(int position)
        {
            this.ValidateOutOfRange(position);

            T[] newArray = new T[this.array.Length - 1];

            for (int i = 0; i < position; i++)
            {
                newArray[i] = this.array[i];
            }

            for (int i = position + 1; i <= newArray.Length; i++)
            {
                newArray[i - 1] = this.array[i];
            }

            this.array = newArray;
            this.count--;
        }

        public void InsertAt(int position, T value)
        {
            this.ValidateOutOfRange(position);

            if (this.array.Length <= position + 1)
            {
                this.ResizeArray();
                this.InsertAtPosition(position, value);
            }
            else
            {
                this.InsertAtPosition(position, value);
            }
        }

        public void Clear()
        {
            this.array = new T[DefaultSize];
            this.count = 0;
        }

        public int Find(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Can't search for null value");
            }

            int result = -1;

            for (int i = 0; i < this.array.Length; i++)
            {
                if (this.array[i] != null)
                {
                    if (this.array[i].CompareTo(value) == 0)
                    {
                        result = i;
                        break;
                    }
                }
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[");

            for (int i = 0; i < this.array.Length; i++)
            {
                if (i == this.array.Length - 1)
                {
                    sb.Append(this.array[i]);
                }
                else
                {
                    sb.Append(this.array[i] + ", ");
                }
            }

            sb.Append("]");

            return sb.ToString();
        }

        public T Min()
        {
            T minValue = this.array[0];

            for (int i = 1; i < this.array.Length; i++)
            {
                if (this.array[i] != null)
                {
                    if (this.array[i].CompareTo(minValue) <= 0)
                    {
                        minValue = this.array[i];
                    }
                }
            }

            return minValue;
        }

        public T Max()
        {
            T maxValue = this.array[0];

            for (int i = 1; i < this.array.Length; i++)
            {
                if (this.array[i] != null)
                {
                    if (this.array[i].CompareTo(maxValue) >= 0)
                    {
                        maxValue = this.array[i];
                    }
                }
            }

            return maxValue;
        }

        private void InsertAtPosition(int position, T value)
        {
            T[] newArray = new T[this.array.Length];
            T oldValue = this.array[position];
            T newValue = value;

            for (int i = 0; i < newArray.Length; i++)
            {
                if (i == position)
                {
                    newArray[i] = newValue;
                }
                else if (i == position + 1)
                {
                    newArray[i] = oldValue;
                }
                else
                {
                    newArray[i] = this.array[i];
                }
            }

            this.array = newArray;
            this.count++;
        }

        private void ResizeArray()
        {
            T[] newArray = new T[this.array.Length * 2];
            Array.Copy(this.array, newArray, this.array.Length);

            this.array = newArray;
        }

        private void ValidateInitialSize(int size)
        {
            if (size < 1)
            {
                throw new ArgumentOutOfRangeException("Size can't be less than one");
            }
        }

        private void ValidateOutOfRange(int position)
        {
            if (position < 0 || position >= this.array.Length)
            {
                throw new IndexOutOfRangeException(string.Format("Invalid index {0}", position));
            }
        }
    }
}
