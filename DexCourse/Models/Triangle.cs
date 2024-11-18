namespace Models;

public class Triangle : IComparable<Triangle>
{
    public int A { get; private init; }
    public int B { get; private init; }
    public int C { get; private init; }
    public double Area { get; }

    public Triangle(int a, int b, int c)
    {
        A = a;
        B = b;
        C = c;
        Area = TriangleArea();
    }

    private double TriangleArea()
    {
        var p = (A + B + C) / 2;
        var radicalExpression = p * (p - A) * (p - B) * (p - C);
        return Math.Sqrt(Math.Abs(radicalExpression));
    }

    public int CompareTo(Triangle? other)
    {
        if (other == null)
        {
            return 1;
        }

        return Area.CompareTo(other.Area);
    }

    public override string ToString()
    {
        return $"Triangle with {A} and {B} and {C} has area {Area}";
    }
}