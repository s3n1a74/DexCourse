using Models.BankModels;
using Services.Exceptions;

namespace Services.Services.Client;

public class ClientService : IClientService
{
    private readonly DateOnly _ageValidationDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-18));
    public Dictionary<Models.BankModels.Client, List<Account>> Clients { get; } = new();

    public void AddClient(Models.BankModels.Client client)
    {
        if (Clients.ContainsKey(client))
        {
            throw new ClientException("Client already exists");
        }

        try
        {
            ValidateClient(client);
            var account = TestDataGenerator.CreateAccount();
            Clients.Add(client, [account]);
        }
        catch (ClientException)
        {
            Console.WriteLine("Invalid parameters, try again");
            throw;
        }
    }

    public void AddAccount(Models.BankModels.Client client, Account account)
    {
        if (!Clients.TryGetValue(client, out var accounts))
        {
            throw new ClientException("Client does not exist");
        }

        try
        {
            ValidateAccount(account);
            accounts.Add(account);
        }
        catch (ClientException e)
        {
            Console.WriteLine($"Client validation failed: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Add operation failed with error: {e.Message}");
        }
    }

    public void UpdateAccount(Models.BankModels.Client client, Account account, Account newAccount)
    {
        if (!Clients.TryGetValue(client, out var value))
        {
            throw new ClientException("Client does not exist");
        }
        try
        {
            ValidateAccount(newAccount);
            value.Remove(account);
            value.Add(newAccount);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private void ValidateClient(Models.BankModels.Client client)
    {
        var validationErrorMessages = new List<string>();
        if (!client.HasPassportData)
        {
            validationErrorMessages.Add("Client does not have passport data");
        }

        if (client.BirthDate >= _ageValidationDate)
        {
            validationErrorMessages.Add("Birth date is earlier than age");
        }

        if (validationErrorMessages.Count != 0)
        {
            throw new ClientException(validationErrorMessages);
        }
    }

    private static void ValidateAccount(Account account)
    {
        if (account.Amount < 0)
        {
            throw new ArgumentException("Account cannot be zero or negative");
        }
    }

}