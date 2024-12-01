using Models.BankModels;

namespace PracticeWithTypes.PracticeExecutors;

public static class FirstChapterExecutor
{
    public static void Execute()
    {
        var employee = new Employee("Danik", new DateOnly(1998, 8, 2), "77712345",
            "slesar4r", 1000, true);
        var modifiedEmployee = ModifyEmployee(employee, "Danik starts working on VDGO");
        Console.WriteLine(modifiedEmployee == employee);
        //Так как ссылка не менялась после изменения объекта, сравнение 2х переменных, в которых хранятся ссылки
        //на один объект, вернет true

        var currency = new Currency("Moldova", "Lei", 17);
        var newCoef = 19;
        var modifiedCurrency = ModifyCurrency(currency, newCoef);
        Console.WriteLine(modifiedCurrency.Equals(currency));
        //2 структуры не являются одинаковыми, тк при передаче структуры как параметра метода и при изменении внутри
        //метода создаются копии первоначальной структуры
    }

    private static Employee ModifyEmployee(Employee employee, string contract)
    {
        var updatedEmployee = employee;
        employee.UpdateContract(contract);
        return updatedEmployee;
    }

    private static Currency ModifyCurrency(Currency currency, double newValueOfCoef)
    {
        var updatedCurrency = currency;
        updatedCurrency.CoefToDollar = newValueOfCoef;
        return updatedCurrency;
    }
}