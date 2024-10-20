using System.Diagnostics;
using Models.BankModels;
using Services;

namespace PracticeWithTypes;

static class Program
{
    public static void Main(string[] args)
    {
        // Глава 1. Типы значений и ссылочные типы.
        var employee = new Employee("Danik", new DateOnly(1998, 8, 2), "77712345", "slesar4r");
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

        // Глава 2. Приведение и преобразование типов.
        var employeeTom = new Employee("Tom", new DateOnly(1978, 8, 2), "77712335", "CEO");
        var employeeDin = new Employee("Din", new DateOnly(1974, 8, 2), "77712355", "CEO");
        var employeeSam = new Employee("Sam", new DateOnly(1986, 8, 2), "77712356", "CEO");

        var employees = new[] { employeeTom, employeeDin, employeeSam };
        var profit = 40484514;
        var expenses = 1000873;

        var firstOwnersSalary = BankService.CalculateBankOwnersSalary(profit, expenses, employees);
        var secondOwnersSalary = BankService.CalculateBankOwnersSalary((decimal)profit, (decimal)expenses, employees);
        var decimalOwnersSalary = BankService.GetDecimalSalary(profit, expenses, employees);

        Console.WriteLine($"{firstOwnersSalary}\t{secondOwnersSalary}\t{decimalOwnersSalary}");
        Console.WriteLine($"Первый подсчет(прибыль и расходы целочисленные) {firstOwnersSalary}");
        Console.WriteLine(
            $"Второй подсчет(прибыль и расходы decimal, но результат целочисленный) {secondOwnersSalary}");
        Console.WriteLine($"Третий подсчет с использованием decimal и округлением до сотых {decimalOwnersSalary}");

        var client = new Client("Tomas ", new DateOnly(1998, 8, 2), "77712345");
        Console.WriteLine($"Клиент: {"",2} {client.Name,-10}\t{client.BirthDate,-10}\t{client.PhoneNumber,-10}");
        var employeeHr = BankService.ClientToEmployee(client, "hr");
        Console.WriteLine(
            $"Сотрудник: {employeeHr.Name,-10}\t{employeeHr.BirthDate,-10}\t{employeeHr.PhoneNumber,-10}" +
            $"\t{employeeHr.Position,-10}");

        // Глава 3: Упаковка и распаковка
        var i = 32939;
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        object obj = i;
        stopwatch.Stop();
        Console.WriteLine($"Время на упаковку: {stopwatch.ElapsedTicks} тиков");

        stopwatch.Reset();
        stopwatch.Start();
        var j = (int)obj;
        stopwatch.Stop();
        Console.WriteLine($"Время на распаковку: {stopwatch.ElapsedTicks} тиков");
        // Единичная упаковка интового значения быстрее распаковки.

        var array = new int[1_000_000];
        for (var s = 0; s < array.Length; s++)
        {
            array[s] = s;
        }

        var boxingResults = new List<long>();
        var unboxingResults = new List<long>();
        var objects = new object[array.Length];
        stopwatch.Reset();
        for (var e = 0; e < array.Length; e++)
        {
            stopwatch.Start();
            var o = (object)array[e];
            stopwatch.Stop();
            objects[e] = o;
            boxingResults.Add(stopwatch.ElapsedTicks);
            stopwatch.Reset();
        }

        stopwatch.Reset();
        foreach (var ob in objects)
        {
            stopwatch.Start();
            var o = (int)ob;
            stopwatch.Stop();
            unboxingResults.Add(stopwatch.ElapsedTicks);
            stopwatch.Reset();
        }

        long boxingSum = 0;
        long unboxingSum = 0;

        foreach (var result in boxingResults)
        {
            boxingSum += result;
        }

        foreach (var result in unboxingResults)
        {
            unboxingSum += result;
        }

        var boxingAverage = (double)boxingSum / boxingResults.Count;
        var unboxingAverage = (double)unboxingSum / unboxingResults.Count;

        Console.WriteLine($"Boxing average2: {boxingAverage}");
        Console.WriteLine($"Unboxing average2: {unboxingAverage}");
        // Среднее значение упаковки миллиона интовых значений больше среднего значения распаковки.
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