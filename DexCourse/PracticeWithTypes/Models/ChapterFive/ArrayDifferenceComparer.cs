using PracticeWithTypes.Models.ChapterFive.EventsArgs;

namespace PracticeWithTypes.Models.ChapterFive;

public class ArrayDifferenceComparer
{
    public event EventHandler<ArrayEventArgs>? ArrayEvent;

    private readonly int _targetItem;
    private readonly int _difference;

    public ArrayDifferenceComparer(int targetItem, int difference)
    {
        _targetItem = targetItem;
        _difference = difference;
    }

    public void Analyze(int[] array)
    {
        var message = $"This element difference to {_targetItem} more than {_difference}";
        foreach (var item in array)
        {
            Console.WriteLine(item);
            if (Math.Abs(100 - (double)item / _targetItem * 100) > _difference)
            {
                ArrayEvent?.Invoke(this, new ArrayEventArgs(message));
            }
        }
    }
}