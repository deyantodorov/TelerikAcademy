namespace BuildedPattern.Interfaces
{
    public interface IItem
    {
        string Name();

        IPackable Packing();

        float Price();
    }
}
