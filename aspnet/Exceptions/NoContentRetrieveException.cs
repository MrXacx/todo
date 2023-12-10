namespace todo.Exceptions;

public class NoContentRetrieveException : Exception
{
    public NoContentRetrieveException() : base() { }
    public NoContentRetrieveException(string? message) : base(message) { }
    public NoContentRetrieveException(string? message, Exception innerException) : base(message, innerException) { }
}