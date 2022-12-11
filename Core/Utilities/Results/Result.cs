
namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool status, string message) : this(status)
        {
            //Status = status;
            Message = message;
        }
        public Result(bool status)
        {
            Status = status;
        }
        public bool Status { get; }
        public string Message { get; }
    }
}
