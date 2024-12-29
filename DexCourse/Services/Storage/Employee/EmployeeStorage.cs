namespace Services.Storage.Employee;

public class EmployeeStorage : IEmployeeStorage
{
    private readonly List<Models.BankModels.Employee> _employees;

    public EmployeeStorage()
    {
        _employees = [];
    }

    public void AddEmployee(Models.BankModels.Employee employee)
    {
        if (!_employees.Contains(employee))
        {
            _employees.Add(employee);
        }
    }

    public IEnumerable<Models.BankModels.Employee> GetAllEmployees()
    {
        return _employees;
    }

    public IEnumerable<Models.BankModels.Employee> GetEmployeesByFilter(
        int page,
        int size,
        string? name = null,
        string? phoneNumber = null,
        bool? hasPassportData = null,
        DateOnly? birthDateStart = null,
        DateOnly? birthDateEnd = null,
        string? position = null,
        int? salary = null)
    {
        return _employees.Where(employee =>
            (string.IsNullOrEmpty(name) || employee.Name.Contains(name)) &&
            (string.IsNullOrEmpty(phoneNumber) || employee.PhoneNumber == phoneNumber) &&
            (!hasPassportData.HasValue || employee.HasPassportData == hasPassportData.Value) &&
            (!birthDateStart.HasValue || employee.BirthDate >= birthDateStart.Value) &&
            (!birthDateEnd.HasValue || employee.BirthDate <= birthDateEnd.Value) && 
            (string.IsNullOrEmpty(position) || employee.Position.Contains(position)) && 
            (!salary.HasValue || salary.Value == employee.Salary))
            .Skip((page - 1) * size)
            .Take(size);
    }
}