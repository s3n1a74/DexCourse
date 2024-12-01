namespace Services.Exceptions;

public class EmployeeException : Exception
{
    public EmployeeException(string? message) : base(message)
    {
    }

    public EmployeeException()
    {
    }

    public EmployeeException(List<string>? messages) : this(messages is null ? null : string.Join(',', messages))
    {
    }
}