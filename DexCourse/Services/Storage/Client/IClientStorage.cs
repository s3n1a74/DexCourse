using Models.BankModels;

namespace Services.Storage.Client;

public interface IClientStorage
{
    IEnumerable<Models.BankModels.Client> GetClientsByFilter(
        int page,
        int size,
        string? name = null,
        string? phoneNumber = null,
        bool? hasPassportData = null,
        DateOnly? birthDateStart = null,
        DateOnly? birthDateEnd = null);

    void AddClient(Models.BankModels.Client client);
}