using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserGenerator.Api.Data.Repositories;
using UserGenerator.Api.DTOs;

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
            return await _context.Users.AsNoTracking().Select(sel => new CreateUserResult(Convert.ToInt32(sel.Id), sel.UserName, sel.Email, "")).ToListAsync();
        }

        public async Task<List<CreateUserResult>> Get(int query)
        {
            var list = _context.Users.Select(sel => new CreateUserResult(Convert.ToInt32(sel.Id), sel.UserName, sel.Email, "")).Take(query);
            return await list.ToListAsync();
        }

        public async Task<CreateUserResult> Get(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            var id = Convert.ToInt32(key);
            return await _context.Users.Select(sel => new CreateUserResult(id, sel.UserName, sel.Email, ""))
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task Add(CreateUserResult result)
        {
            IdentityUser user = new(result.UserName);
            await _context.Users.AddAsync(user).ConfigureAwait(false);
        }

        public async Task AddRangeAsync(IEnumerable<CreateUserResult> results)
        {
            List<IdentityUser> users = new();
            foreach (var result in results)
            {
                users.Add(new IdentityUser(result.UserName) { PasswordHash = result.Password });
            }

            await _context.Users.AddRangeAsync(users);
        }

        public async Task Delete(string key)
        {
            var user = await _context.Users.FindAsync(key);
            _context.Users.Remove(user);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IdentityUser> GetIdentityUser(LoginCommand request)
        {
            return await _context.Users.FirstOrDefaultAsync(f => f.Id == request.Id);

        }
    }
}
