using Models.BankModels;

namespace Services;

public class BankService
{
    public static int CalculateBankOwnersSalary(int profit, int expenses, Employee[] owners)
    {
        return (profit - expenses) / owners.Length;
    }

    public static int CalculateBankOwnersSalary(decimal profit, decimal expenses, Employee[] owners)
    {
        return (int)(profit - expenses) / owners.Length;
    }

    public static decimal GetDecimalSalary(decimal profit, decimal expenses, Employee[] owners)
    {
        return Math.Round((profit - expenses) / owners.Length, 2, MidpointRounding.ToEven);
    }

    //тк в постановке задания указано, что зарплата является типом int, то задачу можно решить 2 способами:
    //1 - прибыль и затраты банка - целочисленные значения. В таком случае при делении на количество владельцев
    //мы можем потерять десятичную часть
    //2 - прибыль и затраты банка - значения типа decimal, как и возвращаемое значение(зарплату можно округлить до
    //сотых).

    public static Employee ClientToEmployee(Client client, string position, int salary)
    {
        return new Employee(client.Name, client.BirthDate, client.PhoneNumber, position, salary, client.HasPassportData);
    }
}