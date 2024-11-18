using Bogus;
using PracticeWithTypes.Extensions;

namespace PracticeWithTypes.PracticeExecutors;

public static class EighthChapterExecutor
{
    public static void Execute()
    {
        var faker = new Faker();
        var triangles = faker.Random.GetRandomTriangle(10);
        Array.Sort(triangles);
        Array.Reverse(triangles);
        foreach (var triangle in triangles)
        {
            var description = triangle.ToString();
            Console.WriteLine(description);
        }
    }
}