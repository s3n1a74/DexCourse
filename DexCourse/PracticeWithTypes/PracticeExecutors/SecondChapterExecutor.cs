using Models.BankModels;
using Services;

namespace PracticeWithTypes.PracticeExecutors;

public static class SecondChapterExecutor
{
    public static void Execute()
    {
        var employeeTom = new Employee("Tom", new DateOnly(1978, 8, 2), "77712335", "CEO",1000);
        var employeeDin = new Employee("Din", new DateOnly(1974, 8, 2), "77712355", "CEO",1000);
        var employeeSam = new Employee("Sam", new DateOnly(1986, 8, 2), "77712356", "CEO",1000);

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
        var employeeHr = BankService.ClientToEmployee(client, "hr",1000);
        Console.WriteLine(
            $"Сотрудник: {employeeHr.Name,-10}\t{employeeHr.BirthDate,-10}\t{employeeHr.PhoneNumber,-10}" +
            $"\t{employeeHr.Position,-10}");
    }
}