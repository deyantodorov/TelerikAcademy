namespace IteratorPattern
{
    public class Iterator : IAbstractDecorator
    {
        private Collection collection;
        private int current = 0;

        public Iterator(Collection collection)
        {
            this.collection = collection;
        }

        public int Step { get; set; }

        public Item First()
        {
            this.current = 0;
            return this.collection[this.current] as Item;
        }

        public Item Next()
        {
            this.current += this.Step;

            if (!this.IsDone)
            {
                return this.collection[this.current] as Item;
            }
            else
            {
                return null;
            }

        }

        public bool IsDone => this.current >= this.collection.Count;

        public Item CurrentItem => this.collection[this.current] as Item;
    }
}
