
namespace Core.Utilities.Results
{
    public interface IDataResult<T> : IResult
    {
        // bool Status { get; }
        //  string Message { get; }
        T Data { get; }
    }
}
