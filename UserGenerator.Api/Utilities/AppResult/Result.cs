namespace UserGenerator.Api.Utilities.AppResult
{
    public class Result : IResult
    {
        public bool Failed => !Succeeded;
        public string Message { get; protected set; }
        public bool Succeeded { get; protected set; }

        public static IResult Fail()
        {
            return new Result { Succeeded = false };
        }
        public static IResult Fail(string message)
        {
            return new Result { Succeeded = false, Message = message };
        }

        public static IResult Success()
        {
            return new Result { Succeeded = true };
        }
        public static IResult Success(string message)
        {
            return new Result { Succeeded = true, Message = message };
        }
    }
    public class Result<TData> : Result, IResult<TData>
    {
        protected Result() { }
        public TData Data { get; protected set; }

        public static IResult<TData> Fail()
        {
            return new Result<TData> { Succeeded = false };
        }
        public static IResult<TData> Fail(string message)
        {
            return new Result<TData> { Succeeded = false, Message = message };
        }

        public static IResult<TData> Success()
        {
            return new Result<TData> { Succeeded = true };
        }
        public static IResult<TData> Success(string message)
        {
            return new Result<TData> { Succeeded = true, Message = message };
        }
        public static IResult<TData> Success(TData data)
        {
            return new Result<TData> { Succeeded = true, Data = data };
        }
        public static IResult<TData> Success(TData data, string message)
        {
            return new Result<TData> { Succeeded = true, Data = data, Message = message };
        }
    }
}
