using Bogus;
using Models.BankModels;

namespace Services;

public static class TestDataGenerator
{
    public static List<Client> GenerateClients(int countOfClients)
    {
        var clients = new List<Client>();
        var faker = new Faker("ru");
        for (var i = 0; i < countOfClients; i++)
        {
            var birthDate = DateOnly.FromDateTime(faker.Date.Between(new DateTime(1960, 10, 6),
                new DateTime(2000, 10, 6)));
            var client = new Client(faker.Name.FullName(), birthDate, faker.Phone.PhoneNumber());
            clients.Add(client);
        }

        return clients;
    }

    public static Dictionary<string, Employee> GenerateDictionaryOfEmployees(int countOfEmployees)
    {
        var employees = new Dictionary<string, Employee>();
        var faker = new Faker("ru");
        for (var i = 0; i < countOfEmployees; i++)
        {
            var birthDate = DateOnly.FromDateTime(faker.Date.Between(new DateTime(1960, 10, 6),
                new DateTime(2000, 10, 6)));
            var employee = new Employee(faker.Person.FirstName, birthDate,
                faker.Phone.PhoneNumber(), faker.Commerce.Department(), faker.Random.Number(10000, 25000));
            employees.Add(employee.PhoneNumber, employee);
        }

        return employees;
    }

    public static List<Employee> GenerateEmployees(int countOfEmployees)
    {
        var employees = new List<Employee>();
        var faker = new Faker("ru");
        for (var i = 0; i < countOfEmployees; i++)
        {
            var birthDate = DateOnly.FromDateTime(faker.Date.Between(new DateTime(1960, 10, 6),
                new DateTime(2000, 10, 6)));
            var employee = new Employee(faker.Person.FirstName, birthDate,
                faker.Phone.PhoneNumber(), faker.Commerce.Department(), faker.Random.Number(10000, 25000));
            employees.Add(employee);
        }

        return employees;
    }
}