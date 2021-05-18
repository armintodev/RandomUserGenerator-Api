using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserGenerator.Api.Data.Repositories;
using UserGenerator.Api.DTOs;
using UserGenerator.Api.Utilities.AppResult;

namespace UserGenerator.Api.Data.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<CreateUserResult>> Get()
        {
            return await _context.Users.AsNoTracking().Select(sel => new CreateUserResult(sel.UserName, sel.Email)).ToListAsync();
        }

        public async Task<List<CreateUserResult>> Get(int query)
        {
            var list = _context.Users.Select(sel => new CreateUserResult(sel.UserName, sel.Email)).Take(query);
            return await list.ToListAsync();
    }

    public Task<TReturn> Get<TReturn>(string key)
    {
        throw new System.NotImplementedException();
    }

    public Task<ApiResult<CreateUserResult>> Add(CreateUserCommand command)
    {
        throw new System.NotImplementedException();
    }
}
}
