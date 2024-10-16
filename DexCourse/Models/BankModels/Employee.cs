namespace Models.BankModels;

public class Employee : Person
{
    public string Position { get; private set; }
    public string? Contract { get; private set; }

    public Employee(string name, DateTime birthDate, string phoneNumber, string position)
        : base(name, birthDate, phoneNumber)
    {
        Position = position;
    }

    public void UpdatePosition(string position)
    {
        Position = position;
    }

    public void UpdateContract(string contract)
    {
        Contract = contract;
    }
}