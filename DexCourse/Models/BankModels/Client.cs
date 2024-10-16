namespace Models.BankModels;

public class Client : Person
{
    public Client(string name, DateTime birthDate, string phoneNumber)
        : base(name, birthDate, phoneNumber)
    {
    }
}