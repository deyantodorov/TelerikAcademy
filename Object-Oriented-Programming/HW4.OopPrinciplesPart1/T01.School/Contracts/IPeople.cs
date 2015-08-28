namespace T01.School.Contracts
{
    public interface IPeople : IComment
    {
        string FirstName { get; }

        string MiddleName { get; }

        string LastName { get; }
    }
}
