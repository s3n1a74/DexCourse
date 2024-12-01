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
            var client = new Client(faker.Name.FullName(), birthDate, faker.Phone.PhoneNumber(), 
                faker.Random.Bool());
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
                faker.Phone.PhoneNumber(), faker.Commerce.Department(), faker.Random.Number(10000, 25000),
                faker.Random.Bool());
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
                faker.Phone.PhoneNumber(), faker.Commerce.Department(), faker.Random.Number(10000, 25000),
                faker.Random.Bool());
            employees.Add(employee);
        }

        return employees;
    }

    public static Dictionary<Client, Account> GenerateDictionaryOfClientsWithSingleAccount(int countOfAccounts)
    {
        var clients = new Dictionary<Client, Account>();
        var faker = new Faker("ru");

        for (var i = 0; i < countOfAccounts; i++)
        {
            var birthDate = DateOnly.FromDateTime(faker.Date.Between(new DateTime(1960, 10, 6),
                new DateTime(2000, 10, 6)));
            var client = new Client(faker.Name.FullName(), birthDate, faker.Phone.PhoneNumber(), 
                faker.Random.Bool());
            var currencyFake = faker.Finance.Currency();
            var currency = new Currency(faker.Address.Country(), currencyFake.Description,
                faker.Random.Double(0.01, 1000));
            var account = new Account(currency, faker.Random.Double(0, 10000));
            clients.Add(client, account);
        }

        return clients;
    }

    public static Dictionary<Client, List<Account>> GenerateDictionaryOfClientsWithSomeAccounts(int countOfAccounts)
    {
        var clients = new Dictionary<Client, List<Account>>();
        var faker = new Faker("ru");
        for (var i = 0; i < countOfAccounts; i++)
        {
            var birthDate = DateOnly.FromDateTime(faker.Date.Between(new DateTime(1960, 10, 6),
                new DateTime(2000, 10, 6)));
            var client = new Client(faker.Name.FullName(), birthDate, faker.Phone.PhoneNumber(), 
                faker.Random.Bool());
            var currencyFake = faker.Finance.Currency();
            var currency = new Currency(faker.Address.Country(), currencyFake.Description,
                faker.Random.Double(0.01, 1000));
            var accounts = new List<Account>
            {
                new Account(currency, faker.Random.Double(0, 10000)),
                new Account(currency, faker.Random.Double(0, 10000))
            };

            clients.Add(client, accounts);
        }

        return clients;
    }

    public static Dictionary<Employee, Account> GenerateDictionaryOfEmployeesWithSingleAccount(int countOfAccounts)
    {
        var employees = new Dictionary<Employee, Account>();
        var faker = new Faker("ru");
        for (int i = 0; i < countOfAccounts; i++)
        {
            var birthDate = DateOnly.FromDateTime(faker.Date.Between(new DateTime(1960, 10, 6),
                new DateTime(2000, 10, 6)));
            var employee = new Employee(faker.Name.FullName(), birthDate, faker.Phone.PhoneNumber(),
                faker.Name.JobTitle(), faker.Random.Number(10000, 25000), faker.Random.Bool());
            var currencyFake = faker.Finance.Currency();
            var currency = new Currency(faker.Address.Country(), currencyFake.Description,
                faker.Random.Double(0.01, 1000));
            var account = new Account(currency, faker.Random.Double(0, 10000));
            employees.Add(employee, account);
        }

        return employees;
    }

    public static Dictionary<Employee, List<Account>> GenerateDictionaryOfEmployeesWithSomeAccounts(int countOfAccounts)
    {
        var employees = new Dictionary<Employee, List<Account>>();
        var faker = new Faker("ru");
        for (var i = 0; i < countOfAccounts; i++)
        {
            var birthDate = DateOnly.FromDateTime(faker.Date.Between(new DateTime(1960, 10, 6),
                new DateTime(2000, 10, 6)));
            var employee = new Employee(faker.Name.FullName(), birthDate, faker.Phone.PhoneNumber(),
                faker.Name.JobTitle(), faker.Random.Number(10000, 25000), faker.Random.Bool());
            var currencyFake = faker.Finance.Currency();
            var currency = new Currency(faker.Address.Country(), currencyFake.Description,
                faker.Random.Double(0.01, 1000));
            var accounts = new List<Account>
            {
                new Account(currency, faker.Random.Double(0, 10000)),
                new Account(currency, faker.Random.Double(0, 10000))
            };

            employees.Add(employee, accounts);
        }

        return employees;
    }
    
    public static Account CreateAccount()
    {
        var faker = new Faker("ru");
        var currency = new Currency(faker.Address.Country(), "Dollar", faker.Random.Double(0.1, 3));
        return new Account(currency, faker.Random.Double(1, 100000));
    }
}