using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UserGenerator.Api.Utilities.AppResult
{
    public sealed class ApiResult : IActionResult
    {
        private readonly IResult _result;
        public ApiResult(IResult result)
        {
            _result = result;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return _result.Failed ? context.UnProcessableEntity(_result.Message) : context.Ok(_result.Message);
        }
    }

    public sealed class ApiResult<TData> : IActionResult
    {
        private readonly IResult<TData> _result;
        public ApiResult(IResult<TData> result)
        {
            _result = result;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return _result.Failed ? context.UnProcessableEntity(_result.Message) : context.Ok(_result.Data);
        }
    }
}
