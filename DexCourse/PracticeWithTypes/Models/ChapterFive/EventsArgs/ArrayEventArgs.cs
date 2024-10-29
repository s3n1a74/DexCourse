namespace PracticeWithTypes.Models.ChapterFive.EventsArgs;

public class ArrayEventArgs : EventArgs
{
    public string Message { get; }

    public ArrayEventArgs(string message)
    {
        Message = message;
    }
}