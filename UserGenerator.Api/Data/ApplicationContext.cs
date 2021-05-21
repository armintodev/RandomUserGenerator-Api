using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UserGenerator.Api.Data
{
    public class ApplicationContext : IdentityDbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityUser>().Ignore(ig => ig.AccessFailedCount)
                .Ignore(ig => ig.ConcurrencyStamp)
                .Ignore(ig => ig.NormalizedUserName)
                .Ignore(ig => ig.LockoutEnabled)
                .Ignore(ig => ig.LockoutEnd)
                .Ignore(ig => ig.SecurityStamp)
                .Ignore(ig => ig.TwoFactorEnabled);

            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityUserToken<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();
        }
    }
}
