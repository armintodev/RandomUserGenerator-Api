using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UserGenerator.Api.Data
{
    public class ApplicationContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }
    }
}
