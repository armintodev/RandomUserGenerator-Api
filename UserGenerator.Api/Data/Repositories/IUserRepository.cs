using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using UserGenerator.Api.DTOs;

namespace UserGenerator.Api.Data.Repositories
{
    public interface IUserRepository
    {
        Task<List<CreateUserResult>> Get();
        Task<List<CreateUserResult>> Get(int query);
        Task<CreateUserResult> Get(string key);
        Task Add(CreateUserResult result);
        Task AddRangeAsync(IEnumerable<CreateUserResult> results);
        Task Delete(string key);
        Task SaveAsync();
        Task<IdentityUser> GetIdentityUser(LoginCommand request);
    }
}
