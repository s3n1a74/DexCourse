using Models.BankModels;
using Services;
using Services.Exceptions;
using Services.Services.Employee;
using Services.Storage.Employee;

namespace ServiceTest.Tests;

public class EmployeeServiceTest
{
    [Fact]
    public void AddNewEmployee_Should_Add_Employee_And_Accounts()
    {
        // Arrange
        var employee = new Employee("John Doe", DateOnly.FromDateTime(DateTime.Now.AddYears(-20)),
            "12345", "HR", 10000, true);
        var service = new EmployeeService();

        // Act
        service.AddEmployee(employee);

        // Assert
        Assert.True(service.Employees.ContainsKey(employee));
    }

    [Fact]
    public void AddNewEmployee_Should_Throw_Exception_If_Employee_Already_Exists()
    {
        // Arrange
        var employee = new Employee("John Doe", DateOnly.FromDateTime(DateTime.Now.AddYears(-20)),
            "12345", "HR", 10000, true);
        var currency = new Currency("USA", "USD", 1.0);
        var account = new Account(currency, 1000);
        var service = new EmployeeService();

        // Act
        service.AddEmployee(employee);
        service.AddAccount(employee, account);

        // Assert
        Assert.Throws<EmployeeException>(() => service.AddEmployee(employee));
    }

    [Fact]
    public void AddAccount_Should_Add_Account_To_Employee()
    {
        // Arrange
        var employee = new Employee("John Doe", DateOnly.FromDateTime(DateTime.Now.AddYears(-20)),
            "12345", "HR", 10000, true);
        var currency = new Currency("USA", "USD", 1.0);
        var newAccount = new Account(currency, 500);
        var service = new EmployeeService();

        // Act
        service.AddEmployee(employee);

        service.AddAccount(employee, newAccount);

        // Assert
        Assert.Equal(2, service.Employees[employee].Count);
        Assert.Contains(newAccount, service.Employees[employee]);
    }

    [Fact]
    public void UpdateAccount_Should_Replace_Account()
    {
        // Arrange
        var employee = new Employee("John Doe", DateOnly.FromDateTime(DateTime.Now.AddYears(-20)),
            "12345", "HR", 10000, true);
        var currency = new Currency("USA", "USD", 1.0);
        var oldAccount = new Account(currency, 1000);
        var newAccount = new Account(currency, 2000);
        var service = new EmployeeService();

        // Act
        service.AddEmployee(employee);

        service.UpdateAccount(employee, oldAccount, newAccount);

        // Assert
        Assert.Contains(newAccount, service.Employees[employee]);
        Assert.DoesNotContain(oldAccount, service.Employees[employee]);
    }

    [Fact]
    public void AddAccount_Should_Throw_Exception_If_Employee_Not_Found()
    {
        // Arrange
        var employee = new Employee("John Doe", DateOnly.FromDateTime(DateTime.Now.AddYears(-20)),
            "12345", "HR", 10000, true);
        var currency = new Currency("USA", "USD", 1.0);
        var account = new Account(currency, 1000);
        var service = new EmployeeService();

        // Assert
        Assert.Throws<EmployeeException>(() => service.AddAccount(employee, account));
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(1)]
    public void AddEmployee_Should_Add_Employee_To_Storage(int countOfGeneratedEmployees)
    {
        // Arrange
        var employees = GetTestEmployees(countOfGeneratedEmployees);

        IEmployeeStorage clientStorage = new EmployeeStorage();
        var storageService = new EmployeeStorageService(clientStorage);

        // Act
        foreach (var employee in employees)
        {
            storageService.AddEmployee(employee);
        }

        var employeesFromStorage = storageService.GetFilteredEmployees(1, 100).ToArray();

        // Assert
        Assert.Equal(countOfGeneratedEmployees, employeesFromStorage.Count());
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    public void GetFilteredEmployees_Should_Return_Youngest_Employee(int countOfGeneratedEmployees)
    {
        // Arrange
        var employees = GetTestEmployees(countOfGeneratedEmployees).ToArray();
        var youngestEmployee = employees.MinBy(p => p.BirthDate);

        IEmployeeStorage clientStorage = new EmployeeStorage();
        var storageService = new EmployeeStorageService(clientStorage);

        // Act
        foreach (var employee in employees)
        {
            storageService.AddEmployee(employee);
        }

        var youngestFilteredEmployee = storageService.GetFilteredEmployees(1, 100).MinBy(p => p.BirthDate);

        // Assert
        Assert.Equal(youngestEmployee, youngestFilteredEmployee);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    public void GetFilteredEmployees_Should_Return_Oldest_Employees(int countOfGeneratedEmployees)
    {
        // Arrange
        var employees = GetTestEmployees(countOfGeneratedEmployees).ToArray();
        var oldestEmployee = employees.MaxBy(p => p.BirthDate);

        IEmployeeStorage employeeStorage = new EmployeeStorage();
        var employeeService = new EmployeeStorageService(employeeStorage);

        // Act
        foreach (var employee in employees)
        {
            employeeService.AddEmployee(employee);
        }
        var oldestFilteredEmployee = employeeService.GetFilteredEmployees(1, 100).MaxBy(p => p.BirthDate);

        // Assert
        Assert.Equal(oldestEmployee, oldestFilteredEmployee);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    public void GetFilteredClients_Should_Return_Middle_Age(int countOfGeneratedEmployees)
    {
        // Arrange
        var employees = GetTestEmployees(countOfGeneratedEmployees).ToArray();
        var averageAge = employees.Select(p => p.BirthDate.Year).Average();

        IEmployeeStorage employeeStorage = new EmployeeStorage();
        var employeeService = new EmployeeStorageService(employeeStorage);

        // Act
        foreach (var employee in employees)
        {
            employeeService.AddEmployee(employee);
        }
        
        var averageAgeFilteredEmployee = employeeService.GetFilteredEmployees(1,100)
            .Select(p => p.BirthDate.Year).Average();
        
        // Assert
        Assert.Equal(averageAge, averageAgeFilteredEmployee);
    }
    
    static IEnumerable<Employee> GetTestEmployees(int count)
    {
        return TestDataGenerator.GenerateEmployees(count);
    }
}