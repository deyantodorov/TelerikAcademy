namespace T03.AnimalHierarchy.Contracts
{
    public interface IAnimal : ISound
    {
        int Age { get; }

        string Name { get; }
    }
}
