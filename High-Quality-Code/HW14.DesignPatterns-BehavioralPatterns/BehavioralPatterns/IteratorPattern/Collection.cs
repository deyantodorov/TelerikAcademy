using System.Collections;

namespace IteratorPattern
{
    public class Collection : IAbstractCollection
    {
        private ArrayList items;

        public Collection()
        {
            this.items = new ArrayList();
        }

        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }

        public int Count => this.items.Count;

        public object this[int index]
        {
            get { return this.items[index]; }
            set { this.items.Add(value); }
        }
    }
}
