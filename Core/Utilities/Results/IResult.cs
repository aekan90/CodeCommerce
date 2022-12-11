namespace Core.Utilities.Results
{
    // Temel voidler için başlangıç
    public interface IResult
    {
        bool Status { get; }
        string Message { get; }
    }
}
