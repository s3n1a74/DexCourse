namespace Services.Exceptions;

public class ClientException : Exception
{
    public ClientException(string? message) : base(message)
    {
    }

    public ClientException()
    {
    }

    public ClientException(List<string>? messages) : this(messages is null ? null : string.Join(',', messages))
    {
    }
}