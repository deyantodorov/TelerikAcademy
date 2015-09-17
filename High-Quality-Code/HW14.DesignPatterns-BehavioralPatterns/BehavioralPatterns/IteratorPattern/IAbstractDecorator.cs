namespace IteratorPattern
{
    public interface IAbstractDecorator
    {
        Item First();
        Item Next();
        bool IsDone { get; }
        Item CurrentItem { get; }
    }
}
