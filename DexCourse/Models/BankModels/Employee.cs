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

    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }
        else if (obj is Employee employee)
        {
            return employee.Name == Name && employee.Position == Position && employee.Contract == Contract 
                   && employee.Salary == Salary && employee.PhoneNumber == PhoneNumber 
                   && employee.BirthDate == BirthDate ;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Position, Contract, Salary, PhoneNumber);
    }
}