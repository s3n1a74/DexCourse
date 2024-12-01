using Models.BankModels;
using Services.Exceptions;

namespace Services;

public class EmployeeService
{
    private readonly DateOnly _ageValidationDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-18));
    public Dictionary<Employee, List<Account>> Employees { get; } = new();

    public void AddEmployee(Employee employee)
    {
        if (Employees.ContainsKey(employee))
        {
            throw new EmployeeException("Employee already exists");
        }

        try
        {
            ValidateEmployee(employee);
            var account = TestDataGenerator.CreateAccount();
            Employees.Add(employee, [account]);
        }
        catch (EmployeeException)
        {
            Console.WriteLine("Invalid parameters, try again");
        }
    }

    public void AddAccount(Employee employee, Account account)
    {
        if (!Employees.TryGetValue(employee, out _))
        {
            throw new EmployeeException("Employee does not exist");
        }

        try
        {
            ValidateAccount(account);
            Employees[employee].Add(account);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void UpdateAccount(Employee employee, Account account, Account newAccount)
    {
        if (!Employees.ContainsKey(employee))
        {
            throw new EmployeeException("Employee does not exist");
        }
        else
        {
            try
            {
                ValidateAccount(newAccount);
                Employees[employee].Remove(account);
                Employees[employee].Add(newAccount);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    private void ValidateEmployee(Employee employee)
    {
        var validationErrorsMessages = new List<string>();
        if (!employee.HasPassportData)
        {
            validationErrorsMessages.Add("Passport data is invalid");
        }

        if (employee.BirthDate >= _ageValidationDate)
        {
            validationErrorsMessages.Add("Birth date is invalid");
        }

        if (employee.Salary <= 0)
        {
            validationErrorsMessages.Add("Salary is invalid");
        }

        if (string.IsNullOrEmpty(employee.Position))
        {
            validationErrorsMessages.Add("Position is invalid");
        }

        if (validationErrorsMessages.Count != 0)
        {
            throw new EmployeeException(validationErrorsMessages);
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