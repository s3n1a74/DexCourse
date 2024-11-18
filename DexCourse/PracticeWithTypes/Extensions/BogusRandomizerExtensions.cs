using Bogus;
using Models;

namespace PracticeWithTypes.Extensions;

public static class BogusRandomizerExtensions
{
    public static Triangle[] GetRandomTriangle(this Randomizer randomizer, int count)
    {
        var triangles = new List<Triangle>();
        
        for (var i = 0; i < count; i++)
        {
            var isValidTriangleSides = false;
            while (!isValidTriangleSides)
            {
                var a = randomizer.Int(1, int.MaxValue / 1000000);
                var b = randomizer.Int(1, int.MaxValue / 1000000);
                var c = randomizer.Int(1, int.MaxValue / 1000000);
                isValidTriangleSides = a + b > c && a + c > b && b + c > a;
                if (isValidTriangleSides)
                {
                    triangles.Add(new Triangle(a, b, c));
                }
            }
        }

        return triangles.ToArray();
    }
}