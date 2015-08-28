namespace T02.Bank.Contracts
{
    public interface ICustomer
    {
        int Id { get; }

        string Name { get; }

        string Address { get; }

        string Country { get; }

        string City { get; }

        string Phone { get; }
    }
}
