namespace Models.BankModels;

public struct Currency
{
    public string Country { get; set; }
    public string Name { get; set; }
    public double CoefToDollar { get; set; }

    public Currency(string country, string name, double coefToDollar)
    {
        Country = country;
        Name = name;
        CoefToDollar = coefToDollar;
    }
}