namespace Models.BankModels;

public class Person
{
    public string Name { get; private set; }
    public DateTime BirthDate { get; private init; }
    public string PhoneNumber { get; private set; }

    protected Person(string name, DateTime birthDate, string phoneNumber)
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