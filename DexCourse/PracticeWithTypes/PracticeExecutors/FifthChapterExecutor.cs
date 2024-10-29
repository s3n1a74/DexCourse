using System.ComponentModel;
using PracticeWithTypes.Models.ChapterFive;
using PracticeWithTypes.Models.ChapterFive.EventsArgs;

namespace PracticeWithTypes.PracticeExecutors;

public class FifthChapterExecutor
{
    public static void Execute()
    {
        var square = new Square(3);
        square.PropertyChanged += Square_PropertyChanged;
        square.A = 100;
        square.PropertyChanged -= Square_PropertyChanged;

        var limitedQueue = new LimitedQueue(3);
        limitedQueue.QueueHandler += OnDisplay;
        limitedQueue.Enqueue(1);
        limitedQueue.Enqueue(2);
        limitedQueue.Enqueue(3);
        limitedQueue.Enqueue(4);
        limitedQueue.QueueHandler -= OnDisplay;
        limitedQueue.DequeueHandler += EmptyQueueEventDisplay;
        limitedQueue.Dequeue();
        limitedQueue.Dequeue();
        limitedQueue.Dequeue();
        limitedQueue.Dequeue();
        limitedQueue.DequeueHandler -= EmptyQueueEventDisplay;

        var comparer = new ArrayDifferenceComparer(50, 20);
        comparer.ArrayEvent += OnDisplay;
        var array = new int[10];
        var random = new Random();
        for (int i = 0; i < 10; i++)
        {
            array[i] = random.Next(0,100);
        }
        comparer.Analyze(array);
    }
    private static void OnDisplay(object? sender, ArrayEventArgs e)
    {
        Console.WriteLine(e.Message);
    }

    private static void OnDisplay(object? sender, QueueEventArgs args)
    {
        Console.WriteLine(args.Message);
    }
    
    private static void Square_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        Console.WriteLine(e.PropertyName);
    }

    static void EmptyQueueEventDisplay(object? sender, QueueEventArgs args)
    {
        Console.WriteLine(args.Message);
    }
}