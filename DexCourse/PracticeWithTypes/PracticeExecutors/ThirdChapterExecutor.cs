using System.Diagnostics;

namespace PracticeWithTypes.PracticeExecutors;

public static class ThirdChapterExecutor
{
    public static void Execute()
    {
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

        var boxingSum = boxingResults.Sum();
        var unboxingSum = unboxingResults.Sum();

        var boxingAverage = (double)boxingSum / boxingResults.Count;
        var unboxingAverage = (double)unboxingSum / unboxingResults.Count;

        Console.WriteLine($"Boxing average2: {boxingAverage}");
        Console.WriteLine($"Unboxing average2: {unboxingAverage}");
        // Среднее значение упаковки миллиона интовых значений больше среднего значения распаковки.
    }
}