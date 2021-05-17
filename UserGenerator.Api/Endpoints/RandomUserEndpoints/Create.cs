using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using UserGenerator.Api.DTOs;
using UserGenerator.Api.Http.Request;

namespace UserGenerator.Api.Endpoints.RandomUserEndpoints
{
    public class Create : BaseAsyncEndpoint.WithRequest<CreateUserCommand>.WithResponse<CreateUserResult>
    {
        [HttpPost("user")]
        public override async Task<ActionResult<CreateUserResult>> HandleAsync(CreateUserCommand request, CancellationToken cancellationToken = new())
        {
            //TODO: request to https://randomuser.me and get detail. second save to database
            //client
            var client = new SendRequest();

            CreateUserResult response;

            if (!request.Request.Equals(""))
                response = await client.SendAsync(request.Request);
            else
                response = await client.SendAsync();

            return response;
        }
    }
}
