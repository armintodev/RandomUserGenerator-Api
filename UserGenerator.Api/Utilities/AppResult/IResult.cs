namespace UserGenerator.Api.Utilities.AppResult
{
    public interface IResult
    {
        bool Failed { get; }
        string Message { get; }
        bool Succeeded { get; }
    }

    public interface IResult<out TData> : IResult
    {
        TData Data { get; }
    }
}
