using Models.BankModels;
using Services;
using Services.Exceptions;

namespace ServiceTest.Tests;

public class EmployeeServiceTest
{
    [Fact]
    public void AddNewEmployee_Should_Add_Employee_And_Accounts()
    {
        var employee = new Employee("John Doe", DateOnly.FromDateTime(DateTime.Now.AddYears(-20)),
            "12345", "HR", 10000, true);
        var service = new EmployeeService();

        service.AddEmployee(employee);

        Assert.True(service.Employees.ContainsKey(employee));
    }

    [Fact]
    public void AddNewEmployee_Should_Throw_Exception_If_Employee_Already_Exists()
    {
        var employee = new Employee("John Doe", DateOnly.FromDateTime(DateTime.Now.AddYears(-20)),
            "12345", "HR", 10000, true);
        var currency = new Currency("USA", "USD", 1.0);
        var account = new Account(currency, 1000);
        var service = new EmployeeService();

        service.AddEmployee(employee);
        service.AddAccount(employee, account);

        Assert.Throws<EmployeeException>(() => service.AddEmployee(employee));
    }

    [Fact]
    public void AddAccount_Should_Add_Account_To_Employee()
    {
        var employee = new Employee("John Doe", DateOnly.FromDateTime(DateTime.Now.AddYears(-20)),
            "12345", "HR", 10000, true);
        var currency = new Currency("USA", "USD", 1.0);
        var newAccount = new Account(currency, 500);
        var service = new EmployeeService();

        service.AddEmployee(employee);

        service.AddAccount(employee, newAccount);

        Assert.Equal(2, service.Employees[employee].Count);
        Assert.Contains(newAccount, service.Employees[employee]);
    }

    [Fact]
    public void UpdateAccount_Should_Replace_Account()
    {
        var employee = new Employee("John Doe", DateOnly.FromDateTime(DateTime.Now.AddYears(-20)),
            "12345", "HR", 10000, true);
        var currency = new Currency("USA", "USD", 1.0);
        var oldAccount = new Account(currency, 1000);
        var newAccount = new Account(currency, 2000);
        var service = new EmployeeService();

        service.AddEmployee(employee);

        service.UpdateAccount(employee, oldAccount, newAccount);

        Assert.Contains(newAccount, service.Employees[employee]);
        Assert.DoesNotContain(oldAccount, service.Employees[employee]);
    }

    [Fact]
    public void AddAccount_Should_Throw_Exception_If_Employee_Not_Found()
    {
        var employee = new Employee("John Doe", DateOnly.FromDateTime(DateTime.Now.AddYears(-20)),
            "12345", "HR", 10000, true);
        var currency = new Currency("USA", "USD", 1.0);
        var account = new Account(currency, 1000);
        var service = new EmployeeService();

        Assert.Throws<EmployeeException>(() => service.AddAccount(employee, account));
    }
}