using System.Collections.Generic;
using System.Threading.Tasks;
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
    }
}
