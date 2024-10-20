namespace Models.BankModels;

public class Person
{
    public string Name { get; private set; }
    public DateOnly BirthDate { get; private init; }
    public string PhoneNumber { get; private set; }

    protected Person(string name, DateOnly birthDate, string phoneNumber)
    {
        Name = name;
        BirthDate = birthDate;
        PhoneNumber = phoneNumber;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }

    public void UpdatePhoneNumber(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
    }
}