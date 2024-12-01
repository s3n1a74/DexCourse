namespace Models.BankModels;

public class Client : Person
{
    public Client(string name, DateOnly birthDate, string phoneNumber, bool hasPassportData)
        : base(name, birthDate, phoneNumber, hasPassportData)
    {
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }

        if (obj is Client c)
        {
            return c.Name == Name && c.BirthDate == BirthDate && c.PhoneNumber == PhoneNumber &&
                   c.HasPassportData == HasPassportData;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, BirthDate, PhoneNumber, HasPassportData);
    }
}