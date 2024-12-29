using Services.Storage.Employee;

namespace Services.Services.Employee;

public class EmployeeStorageService : IEmployeeService
{
    private readonly IEmployeeStorage _employeeStorage;
    
    public EmployeeStorageService(IEmployeeStorage employeeStorage)
    {
        _employeeStorage = employeeStorage;
    }
    
    public IEnumerable<Models.BankModels.Employee> GetFilteredEmployees(
        int page,
        int size,
        string? name = null,
        string? phoneNumber = null,
        bool? hasPassportData = null,
        DateOnly? birthDateStart = null,
        DateOnly? birthDateEnd = null)
    {
        return _employeeStorage.GetEmployeesByFilter(
            page,
            size,
            name, 
            phoneNumber, 
            hasPassportData, 
            birthDateStart, 
            birthDateEnd);
    }

    public void AddEmployee(Models.BankModels.Employee employee)
    {
        _employeeStorage.AddEmployee(employee);
    }
}