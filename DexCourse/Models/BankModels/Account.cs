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
    
    public override bool Equals(object obj)
    {
        if (obj is Account other)
        {
            return Currency.Equals(other.Currency) && Amount == other.Amount;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Currency, Amount);
    }
}