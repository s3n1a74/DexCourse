using System.ComponentModel;

namespace PracticeWithTypes.Models.ChapterFive;

public class Square : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private int _a;

    public int A
    {
        get => _a;
        set
        {
            if (value > 0)
            {
                _a = value;
                OnPropertyChanged();
            }
            else
            {
                throw new ArgumentException("Значение стороны квадрата должно быть больше нуля.");
            }
        }
    }

    public Square(int a)
    {
        A = a;
    }

    private void OnPropertyChanged()
    {
        var message = "value of field be edited";
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(message));
    }
}