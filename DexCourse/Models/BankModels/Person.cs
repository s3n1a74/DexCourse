namespace Models.BankModels;

public class Person
{
    public string Name { get; private set; }
    public DateOnly BirthDate { get; private init; }
    public string PhoneNumber { get; private set; }
    public bool HasPassportData { get;private set; }

    protected Person(string name, DateOnly birthDate, string phoneNumber, bool hasPassportData)
    {
        Name = name;
        BirthDate = birthDate;
        PhoneNumber = phoneNumber;
        HasPassportData = hasPassportData;
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