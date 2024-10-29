using PracticeWithTypes.Models.ChapterFive.EventsArgs;

namespace PracticeWithTypes.Models.ChapterFive;

public class LimitedQueue
{
    public EventHandler<QueueEventArgs>? QueueHandler;
    public EventHandler<QueueEventArgs>? DequeueHandler;

    private readonly int _counterLimit;
    private readonly Queue<int> _queue = new();

    public LimitedQueue(int counterLimit)
    {
        _counterLimit = counterLimit;
    }

    public void Enqueue(int value)
    {
        _queue.Enqueue(value);
        if (_queue.Count >= _counterLimit)
        {
            var message = $"Очередь содержит более {_counterLimit} элементов";
            QueueHandler?.Invoke(this, new QueueEventArgs(message));
        }
    }

    public int Dequeue()
    {
        var value = _queue.Dequeue();
        var message = "Очередь пустая";
        if (_queue.Count == 0)
        {
            DequeueHandler?.Invoke(this, new QueueEventArgs(message));
        }

        return value;
    }
}