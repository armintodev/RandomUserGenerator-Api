using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UserGenerator.Api.Utilities.AppResult
{
    public static class ActionContextExtensions
    {
        public static Task Ok(this ActionContext context, object value)
        {
            return new OkObjectResult(value).ExecuteResultAsync(context);
        }

        public static Task UnProcessableEntity(this ActionContext context, string error)
        {
            return new UnprocessableEntityObjectResult(error).ExecuteResultAsync(context);
        }
    }
}
