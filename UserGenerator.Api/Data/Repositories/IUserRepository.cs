using System.Collections.Generic;
using System.Threading.Tasks;
using UserGenerator.Api.DTOs;
using UserGenerator.Api.Utilities.AppResult;

namespace UserGenerator.Api.Data.Repositories
{
    interface IUserRepository
    {
        Task<List<CreateUserResult>> Get();
        Task<List<CreateUserResult>> Get(int query);
        Task<TReturn> Get<TReturn>(string key);
        Task<ApiResult<CreateUserResult>> Add(CreateUserCommand command);
    }
}
