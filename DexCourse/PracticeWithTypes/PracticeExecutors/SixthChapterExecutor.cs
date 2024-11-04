using System.Diagnostics;
using Services;

namespace PracticeWithTypes.PracticeExecutors;

public static class SixthChapterExecutor
{
    public static void Execute()
    {
        var employees = TestDataGenerator.GenerateEmployees(1000);
        var employeesDictionary = TestDataGenerator.GenerateDictionaryOfEmployees(1000);
        var clients = TestDataGenerator.GenerateClients(1000);

        var phone = employees[683].PhoneNumber;
        var sw = new Stopwatch();
        sw.Start();
        var employee = employees.First(x => x.PhoneNumber == phone);
        sw.Stop();
        Console.WriteLine(sw.ElapsedTicks + " - Время поиска по номеру телефона в списке сотрудников");

        var employeesDictionaryKey = employeesDictionary.ElementAt(683).Key;
        sw.Restart();
        employeesDictionary.TryGetValue(employeesDictionaryKey, out var employeefromDictionary);
        sw.Stop();
        Console.WriteLine(sw.ElapsedTicks + " - Время поиска по ключу (по номеру телефона) из словаря");

        sw.Restart();
        var clientsYounger40 = clients.FindAll(x => x.BirthDate.Year < 40);
        sw.Stop();
        Console.WriteLine(sw.ElapsedTicks + " - время выборки клиентов, возраст которых меньше определенного значения");

        sw.Restart();
        var employeeWithMinimalSalary = employees.Min(x => x.Salary);
        sw.Stop();
        Console.WriteLine(sw.ElapsedTicks + " - Время поиска сотрудника с минимальной зп в списке");

        sw.Restart();
        var lastEmployeeFromList = employeesDictionary.LastOrDefault();
        sw.Stop();
        Console.WriteLine(sw.ElapsedTicks + " - поиск последнего элемента в словаре методом LastOrDefault()");
        sw.Reset();

        var phoneNumberFromDictionary = employeesDictionary.ElementAt(999).Key;
        sw.Restart();
        employeesDictionary.TryGetValue(phoneNumberFromDictionary, out var lastEmployeeFromDictionary);
        sw.Stop();
        Console.WriteLine(sw.ElapsedTicks + " - поиск последнего элемента в словаре по ключу");
    }
}