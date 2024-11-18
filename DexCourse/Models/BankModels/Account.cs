namespace Models.BankModels;

public class Account
{
    public Currency Currency { get;private init; }
    public double Amount { get; private set; }

    public Account(Currency currency, double amount)
    {
        Currency = currency;
        Amount = amount;
    }
}