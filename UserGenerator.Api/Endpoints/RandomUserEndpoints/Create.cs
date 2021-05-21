using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using UserGenerator.Api.Data.Repositories;
using UserGenerator.Api.DTOs;
using UserGenerator.Api.Http.Request;

namespace UserGenerator.Api.Endpoints.RandomUserEndpoints
{
    public class Create : BaseAsyncEndpoint.WithRequest<CreateUserCommand>.WithResponse<List<CreateUserResult>>
    {
        private readonly IUserRepository _userRepository;
        public Create(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("user")]
        public override async Task<ActionResult<List<CreateUserResult>>> HandleAsync(CreateUserCommand request, CancellationToken cancellationToken = new())
        {
            if (request.Skip < request.Request)
            {
                //client
                SendRequest client = new();

                //skip user
                int skip = request.Skip is not 0 ? request.Skip : 1;

                CreateUserResult response;
                List<CreateUserResult> responses = new(request.Request);

                if (request.Request is not 0)
                    for (int i = skip; i <= request.Request; i++)
                    {
                        client = new();
                        response = await client.SendAsync(i);
                        responses.Add(new CreateUserResult(response.Id, response.UserName, response.Email, request.Password));
                    }

                else
                    for (int i = skip; i <= 10; i++)
                    {
                        client = new();
                        response = await client.SendAsync(i);
                        responses.Add(response);
                    }

                if (responses is not null)
                {
                    //save to db
                    await _userRepository.AddRangeAsync(responses);

                    await _userRepository.SaveAsync();
                }
                return responses;
            }

            return BadRequest("skip user can't be greater than request user");
        }
    }
}
