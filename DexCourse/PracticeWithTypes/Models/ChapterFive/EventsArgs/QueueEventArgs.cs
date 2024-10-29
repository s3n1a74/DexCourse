namespace PracticeWithTypes.Models.ChapterFive.EventsArgs;

public class QueueEventArgs : EventArgs
{
    public string Message { get; }

    public QueueEventArgs(string message)
    {
        Message = message;
    }
}