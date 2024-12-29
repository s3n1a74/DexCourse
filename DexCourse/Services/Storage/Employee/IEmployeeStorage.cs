namespace Services.Storage.Employee;

public interface IEmployeeStorage
{
    public IEnumerable<Models.BankModels.Employee> GetAllEmployees();

    public IEnumerable<Models.BankModels.Employee> GetEmployeesByFilter(
        int page,
        int size,
        string? name = null,
        string? phoneNumber = null,
        bool? hasPassportData = null,
        DateOnly? birthDateStart = null,
        DateOnly? birthDateEnd = null,
        string? position = null,
        int? salary = null);

    void AddEmployee(Models.BankModels.Employee employee);
}