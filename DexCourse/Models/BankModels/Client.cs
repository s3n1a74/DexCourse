namespace Models.BankModels;

public class Client : Person
{
    public Client(string name, DateOnly birthDate, string phoneNumber)
        : base(name, birthDate, phoneNumber)
    {
    }
}