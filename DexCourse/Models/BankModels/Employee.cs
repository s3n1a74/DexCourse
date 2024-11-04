namespace Models.BankModels;

public class Employee : Person
{
    public string Position { get; private set; }
    public string? Contract { get; private set; }
    public int Salary { get; private set; }

    public Employee(string name, DateOnly birthDate, string phoneNumber, string position, int salary)
        : base(name, birthDate, phoneNumber)
    {
        Position = position;
        Salary = salary;
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