using Services.Storage.Client;

namespace Services.Services.Client;

public class ClientStorageService : IClientService
{
    private readonly IClientStorage _clientStorage;

    public ClientStorageService(IClientStorage clientStorage)
    {
        _clientStorage = clientStorage;
    }

    public IEnumerable<Models.BankModels.Client> GetFilteredClients(
        int page,
        int size,
        string? name = null,
        string? phoneNumber = null,
        bool? hasPassportData = null,
        DateOnly? birthDateStart = null,
        DateOnly? birthDateEnd = null)
    {
        return _clientStorage.GetClientsByFilter(
            page, 
            size, 
            name, 
            phoneNumber, 
            hasPassportData, 
            birthDateStart,
            birthDateEnd);
    }

    public void AddClient(Models.BankModels.Client client)
    {
        _clientStorage.AddClient(client);
    }
}