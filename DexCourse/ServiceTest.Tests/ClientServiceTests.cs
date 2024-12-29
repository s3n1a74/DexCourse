using Models.BankModels;
using Services;
using Services.Exceptions;
using Services.Services.Client;
using Services.Storage.Client;

namespace ServiceTest.Tests;

public class ClientServiceTests
{
    [Fact]
    public void AddNewClient_Should_Add_Client_And_Accounts()
    {
        // Arrange
        var client = new Client(
            "John Doe",
            DateOnly.FromDateTime(DateTime.Now.AddYears(-20)),
            "12345",
            true);

        var service = new ClientService();

        // Act
        service.AddClient(client);

        // Assert
        Assert.True(service.Clients.ContainsKey(client));
    }

    [Fact]
    public void AddNewClient_Should_Throw_Exception_If_Client_Already_Exists()
    {
        // Arrange
        var client = new Client(
            "John Doe",
            DateOnly.FromDateTime(DateTime.Now.AddYears(-20)),
            "12345",
            true);
        var currency = new Currency("USA", "USD", 1.0);
        var account = new Account(currency, 1000);
        var service = new ClientService();

        // Act
        service.AddClient(client);
        service.AddAccount(client, account);

        // Assert
        Assert.Throws<ClientException>(() => service.AddClient(client));
    }

    [Fact]
    public void AddAccount_Should_Add_Account_To_Client()
    {
        // Arrange
        var client = new Client(
            "John Doe",
            DateOnly.FromDateTime(DateTime.Now.AddYears(-20)),
            "12345",
            true);
        var currency = new Currency("USA", "USD", 1.0);
        var newAccount = new Account(currency, 500);
        var service = new ClientService();

        // Act
        service.AddClient(client);

        service.AddAccount(client, newAccount);

        // Assert
        Assert.Equal(2, service.Clients[client].Count);
        Assert.Contains(newAccount, service.Clients[client]);
    }

    [Fact]
    public void UpdateAccount_Should_Replace_Account()
    {
        // Arrange
        var client = new Client(
            "John Doe",
            DateOnly.FromDateTime(DateTime.Now.AddYears(-20)),
            "12346",
            true);
        var currency = new Currency("USA", "USD", 1.0);
        var oldAccount = new Account(currency, 1000);
        var newAccount = new Account(currency, 2000);
        var service = new ClientService();

        // Act
        service.AddClient(client);

        service.UpdateAccount(client, oldAccount, newAccount);

        // Assert
        Assert.Contains(newAccount, service.Clients[client]);
        Assert.DoesNotContain(oldAccount, service.Clients[client]);
    }

    [Fact]
    public void AddAccount_Should_Throw_Exception_If_Client_Not_Found()
    {
        //Arrange
        var client = new Client(
            "John Doe",
            DateOnly.FromDateTime(DateTime.Now.AddYears(-20)),
            "12347",
            true);
        var currency = new Currency("USA", "USD", 1.0);
        var account = new Account(currency, 1000);
        var service = new ClientService();
        
        // Assert
        Assert.Throws<ClientException>(() => service.AddAccount(client, account));
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(1)]
    public void AddClient_Should_Add_Client_To_Storage(int countOfGeneratedClients)
    {
        // Arrange
        var clients = GetTestClients(countOfGeneratedClients);

        IClientStorage clientStorage = new ClientStorage();
        var clientService = new ClientStorageService(clientStorage);

        // Act
        foreach (var client in clients)
        {
            clientService.AddClient(client);
        }

        var clientsFromStorage = clientService.GetFilteredClients(1, 100).ToArray();

        // Assert
        Assert.Equal(countOfGeneratedClients, clientsFromStorage.Count());
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    public void GetFilteredClients_Should_Return_Youngest_Client(int countOfGeneratedClients)
    {
        // Arrange
        var clients = GetTestClients(countOfGeneratedClients).ToArray();
        var youngestClient = clients.MinBy(p => p.BirthDate);

        IClientStorage clientStorage = new ClientStorage();
        var clientService = new ClientStorageService(clientStorage);

        // Act
        foreach (var client in clients)
        {
            clientService.AddClient(client);
        }

        var youngestFilteredClient = clientService.GetFilteredClients(1, 100).MinBy(p => p.BirthDate);

        // Assert
        Assert.Equal(youngestClient, youngestFilteredClient);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    public void GetFilteredClients_Should_Return_Oldest_Client(int countOfGeneratedClients)
    {
        // Arrange
        var clients = GetTestClients(countOfGeneratedClients).ToArray();
        var oldestClient = clients.MaxBy(p => p.BirthDate);

        IClientStorage clientStorage = new ClientStorage();
        var clientService = new ClientStorageService(clientStorage);

        // Act
        foreach (var client in clients)
        {
            clientService.AddClient(client);
        }
        var oldestFilteredClient = clientService.GetFilteredClients(1, 100).MaxBy(p => p.BirthDate);

        // Assert
        Assert.Equal(oldestClient, oldestFilteredClient);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    public void GetFilteredClients_Should_Return_Middle_Age(int countOfGeneratedClients)
    {
        // Arrange
        var clients = GetTestClients(countOfGeneratedClients).ToArray();
        var averageAge = clients.Select(p => p.BirthDate.Year).Average();

        IClientStorage clientStorage = new ClientStorage();
        var clientService = new ClientStorageService(clientStorage);

        // Act
        foreach (var client in clients)
        {
            clientService.AddClient(client);
        }
        
        var averageAgeFilteredClients = clientService.GetFilteredClients(1,100)
            .Select(p => p.BirthDate.Year).Average();
        
        // Assert
        Assert.Equal(averageAge, averageAgeFilteredClients);
    }

    private static IEnumerable<Client> GetTestClients(int count)
    {
        return TestDataGenerator.GenerateClients(count);
    }
}