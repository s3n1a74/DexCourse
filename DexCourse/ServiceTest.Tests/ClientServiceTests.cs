using Models.BankModels;
using Services;
using Services.Exceptions;

namespace ServiceTest.Tests;

public class ClientServiceTests
{
    [Fact]
    public void AddNewClient_Should_Add_Client_And_Accounts()
    {
        var client = new Client("John Doe", DateOnly.FromDateTime(DateTime.Now.AddYears(-20)), "12345",
            true);
        var service = new ClientService();

        service.AddClient(client);

        Assert.True(service.Clients.ContainsKey(client));
    }
    
    [Fact]
    public void AddNewClient_Should_Throw_Exception_If_Client_Already_Exists()
    {
        var client = new Client("John Doe", DateOnly.FromDateTime(DateTime.Now.AddYears(-20)), "12345",
            true);
        var currency = new Currency("USA", "USD", 1.0);
        var account = new Account(currency, 1000) ;
        var service = new ClientService();

        service.AddClient(client);
        service.AddAccount(client, account);

        Assert.Throws<ClientException>(() => service.AddClient(client));
    }
    
    [Fact]
    public void AddAccount_Should_Add_Account_To_Client()
    {
        var client = new Client("John Doe", DateOnly.FromDateTime(DateTime.Now.AddYears(-20)), "12345",
            true);
        var currency = new Currency("USA", "USD", 1.0);
        var newAccount = new Account(currency, 500);
        var service = new ClientService();

        service.AddClient(client);

        service.AddAccount(client, newAccount);

        Assert.Equal(2, service.Clients[client].Count);
        Assert.Contains(newAccount, service.Clients[client]);
    }

    [Fact]
    public void UpdateAccount_Should_Replace_Account()
    {
        var client = new Client("John Doe", DateOnly.FromDateTime(DateTime.Now.AddYears(-20)), "12346",
            true);
        var currency = new Currency("USA", "USD", 1.0);
        var oldAccount = new Account(currency, 1000);
        var newAccount = new Account(currency, 2000);
        var service = new ClientService();

        service.AddClient(client);

        service.UpdateAccount(client, oldAccount, newAccount);
        
        Assert.Contains(newAccount, service.Clients[client]);
        Assert.DoesNotContain(oldAccount, service.Clients[client]);
    }

    [Fact]
    public void AddAccount_Should_Throw_Exception_If_Client_Not_Found()
    {
        var client = new Client("John Doe", DateOnly.FromDateTime(DateTime.Now.AddYears(-20)), "12347", 
            true);
        var currency = new Currency("USA", "USD", 1.0);
        var account = new Account(currency, 1000);
        var service = new ClientService();

        Assert.Throws<ClientException>(() => service.AddAccount(client, account));
    }
}