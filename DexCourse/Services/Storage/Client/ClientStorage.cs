using Models.BankModels;

namespace Services.Storage.Client;

public class ClientStorage : IClientStorage
{
    private readonly List<Models.BankModels.Client> _clients = [];

    public IEnumerable<Models.BankModels.Client> GetClientsByFilter(
        int page,
        int size,
        string? name = null,
        string? phoneNumber = null,
        bool? hasPassportData = null,
        DateOnly? birthDateStart = null,
        DateOnly? birthDateEnd = null)
    {
        return _clients.Where(client =>
                (string.IsNullOrEmpty(name) || client.Name.Contains(name)) &&
                (string.IsNullOrEmpty(phoneNumber) || client.PhoneNumber == phoneNumber) &&
                (!hasPassportData.HasValue || client.HasPassportData == hasPassportData.Value) &&
                (!birthDateStart.HasValue || client.BirthDate >= birthDateStart.Value) &&
                (!birthDateEnd.HasValue || client.BirthDate <= birthDateEnd.Value))
            .Skip((page-1)*size)
            .Take(size);
    }

    public void AddClient(Models.BankModels.Client client)
    {
        if (!_clients.Contains(client))
        {
            _clients.Add(client);
        }
    }
}