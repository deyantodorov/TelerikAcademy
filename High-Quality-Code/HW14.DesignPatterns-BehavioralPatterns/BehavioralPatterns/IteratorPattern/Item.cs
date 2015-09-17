namespace IteratorPattern
{
    public class Item
    {
        public Item(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}
