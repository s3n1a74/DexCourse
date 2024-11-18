using Models.BankModels;
using Services;

namespace ServiceTest.Tests;

public class EquivalenceTests
{
    [Fact]
    public void GetHashCodeNecessityPositiveTestForClients()
    {
        var clients = TestDataGenerator.GenerateDictionaryOfClientsWithSingleAccount(100);
        var client = clients.ElementAt(56).Key;
        var testClient = new Client(client.Name, client.BirthDate, client.PhoneNumber);

        Assert.True(clients.TryGetValue(testClient, out _));
    }

    [Fact]
    public void GetHashCodeNecessityPositiveTestForClientsWithSomeAccounts()
    {
        var clients = TestDataGenerator.GenerateDictionaryOfClientsWithSomeAccounts(100);
        var client = clients.ElementAt(56).Key;
        var testClient = new Client(client.Name, client.BirthDate, client.PhoneNumber);

        Assert.True(clients.TryGetValue(testClient, out _));
    }

    [Fact]
    public void GetHashCodeNecessityPositiveTestForEmployees()
    {
        var employees = TestDataGenerator.GenerateDictionaryOfEmployeesWithSingleAccount(100);
        var employee = employees.ElementAt(56).Key;
        var testEmployee = new Employee(employee.Name, employee.BirthDate, employee.PhoneNumber,
            employee.Position, employee.Salary);

        Assert.True(employees.TryGetValue(testEmployee, out _));
    }

    [Fact]
    public void GetHashCodeNecessityPositiveTestForSomeAccounts_ForEmployees()
    {
        var employees = TestDataGenerator.GenerateDictionaryOfEmployeesWithSomeAccounts(100);
        var employee = employees.ElementAt(56).Key;
        var testClient = new Employee(employee.Name, employee.BirthDate, employee.PhoneNumber,
            employee.Position, employee.Salary);

        Assert.True(employees.TryGetValue(testClient, out _));
    }
}