namespace Models.BankModels;

public class Client : Person
{
    public Client(string name, DateOnly birthDate, string phoneNumber)
        : base(name, birthDate, phoneNumber)
    {
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }
        else if (obj is Client c)
        {
            return c.Name == Name && c.BirthDate == BirthDate && c.PhoneNumber == PhoneNumber;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, BirthDate, PhoneNumber);
    }
}